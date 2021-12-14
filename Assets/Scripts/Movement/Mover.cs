#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SteeringBehaviors.Movement
{
    [GenerateMonoBehaviour]
    public class Mover : IDisposable
    {
        protected delegate float Normalizer(float value01);

        protected static class Normalizers
        {
            public static readonly Normalizer Default = v => v;
            public static readonly Normalizer Inverse = v => 1.0f - v;
            public static readonly Normalizer PermanentMax = v => 1.0f;
        }

        protected readonly Transform Movable;
        protected readonly float MaxSpeed;
        protected readonly MoveImpactInfos ImpactInfos;
        protected readonly Bounds Bounds;

        public readonly List<Transform> Dangers = new List<Transform>();
        public readonly List<Transform> Preys = new List<Transform>();
        public readonly List<Transform> Friends = new List<Transform>();

        protected bool IsAlive = true;

        public Mover(
            Transform movable, float maxSpeed, MoveImpactInfos impactInfos,
            Bounds bounds, Transform[] dangers, Transform[] preys, Transform[] friends
        )
        {
            Movable = movable;
            MaxSpeed = maxSpeed;
            ImpactInfos = impactInfos;
            Bounds = bounds;

            Dangers = new List<Transform>(dangers);
            Preys = new List<Transform>(preys);
            Friends = new List<Transform>(friends);

            MoveAsync();
        }

        protected async Task MoveAsync()
        {
            while (IsAlive)
            {
                MoveFrame();

                await Task.Yield();
            }
        }

        private void MoveFrame() => MoveFrame(Dangers, Preys, Friends);

        private void MoveFrame(
            IEnumerable<Transform> dangers, IEnumerable<Transform> preys, IEnumerable<Transform> friends
        )
        {
            //Vector3 dangerPosition = GetAveragePosition(dangers);
            //Vector3 preysPosition = GetAveragePosition(preys);
            //Vector3 friendsPosition = GetAveragePosition(friends);

            Vector3 goalDirection = Vector3.zero;

            foreach (Transform danger in dangers)
            {
                //goalDirection += GetDangerImpact(danger.position);
                goalDirection += -GetImpactTo(danger.position, ImpactInfos.EscapeEnemy, Normalizers.Inverse);
            }

            foreach (Transform prey in preys)
            {
                //goalDirection += GetPreyImpact(prey.position);
                goalDirection += GetImpactTo(prey.position, ImpactInfos.PursuePrey, Normalizers.PermanentMax);
            }

            foreach (Transform friend in friends)
            {
                //goalDirection += GetPreyImpact(friend.position);
                //goalDirection += GetDangerImpact(friend.position);
                goalDirection += GetImpactTo(friend.position, ImpactInfos.FollowFriend, Normalizers.Default);
                goalDirection += -GetImpactTo(friend.position, ImpactInfos.EscapeFriend, Normalizers.Inverse);
            }

            goalDirection += GetBoundsImpact(Bounds);

            Movable.position += MaxSpeed * Time.deltaTime * Vector3.ClampMagnitude(goalDirection, 1.0f);

            if (goalDirection != Vector3.zero)
            {
                Movable.rotation = Quaternion.LookRotation(goalDirection, Vector3.up);
            }
        }

        protected virtual Vector3 GetDangerImpact(Vector3 danger)
        {
            Vector3 escapeDirection = Movable.position - danger;

            float distance01 = Mathf.InverseLerp(ImpactInfos.EscapeEnemy.Distance.Min, ImpactInfos.EscapeEnemy.Distance.Max, escapeDirection.magnitude);

            return ImpactInfos.EscapeEnemy.Priority * (1 - distance01) * escapeDirection.normalized;
        }

        protected virtual Vector3 GetImpactTo(Vector3 position, MoveImpactInfo impactInfo, Normalizer normalizer)
            => GetImpactTo(position, impactInfo.Distance, impactInfo.Priority, normalizer);

        protected virtual Vector3 GetImpactTo(
            Vector3 position, Range<float> impactDistance, float priority, Normalizer normalizer
        )
        {
            Vector3 pursueDirection = position - Movable.position;

            float distance01 = Mathf.InverseLerp(impactDistance.Min, impactDistance.Max, pursueDirection.magnitude);

            distance01 = normalizer(distance01);

            return priority * distance01 * pursueDirection.normalized;
        }

        protected virtual Vector3 GetPreyImpact(Vector3 prey)
        {
            Vector3 pursueDirection = prey - Movable.position;

            float distance01 = Mathf.InverseLerp(ImpactInfos.PursuePrey.Distance.Min, ImpactInfos.PursuePrey.Distance.Max, pursueDirection.magnitude);

            return ImpactInfos.PursuePrey.Priority * /*(1 - distance01) **/ pursueDirection.normalized;
        }

        protected virtual Vector3 GetBoundsImpact(Bounds bounds)
        {
            Vector3 distance01 = Vector3.zero;

            distance01.x = -1.0f
                         + Mathf.InverseLerp(
                               ImpactInfos.KeepBounds.Distance.Min,
                               ImpactInfos.KeepBounds.Distance.Max,
                               bounds.max.x - Movable.position.x
                           );

            distance01.x += 1.0f
                          - Mathf.InverseLerp(
                                ImpactInfos.KeepBounds.Distance.Min,
                                ImpactInfos.KeepBounds.Distance.Max,
                                Movable.position.x - bounds.min.x
                            );

            distance01.z = -1.0f
                         + Mathf.InverseLerp(
                               ImpactInfos.KeepBounds.Distance.Min,
                               ImpactInfos.KeepBounds.Distance.Max,
                               bounds.max.z - Movable.position.z
                           );

            distance01.z += 1.0f
                          - Mathf.InverseLerp(
                                ImpactInfos.KeepBounds.Distance.Min,
                                ImpactInfos.KeepBounds.Distance.Max,
                                Movable.position.z - bounds.min.z
                            );

            return ImpactInfos.KeepBounds.Priority * Vector3.ClampMagnitude(distance01, 1.0f);
        }

        protected Vector3 GetAveragePosition(IEnumerable<Transform> transforms)
        {
            return transforms.Select(transform => transform.position).Aggregate((p1, p2) => p1 + p2)
                 / transforms.Count();
        }

        public void Dispose() => IsAlive = false;
    }

    [Serializable]
    public struct MoveImpactInfos
    {
        public MoveImpactInfo Wander;
        public MoveImpactInfo EscapeEnemy;
        public MoveImpactInfo PursuePrey;
        public MoveImpactInfo FollowFriend;
        public MoveImpactInfo EscapeFriend;
        public MoveImpactInfo KeepBounds;
    }

    [Serializable]
    public struct MoveImpactInfo
    {
        public float Priority;
        public Range<float> Distance;
    }
}

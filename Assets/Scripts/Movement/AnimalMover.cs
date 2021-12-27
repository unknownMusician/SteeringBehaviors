#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SteeringBehaviors.Movement
{
    [GenerateMonoBehaviour]
    public class AnimalMover : Mover
    {
        protected delegate float Normalizer(float value01);

        protected static class Normalizers
        {
            public static readonly Normalizer Default = v => v;
            public static readonly Normalizer Inverse = v => 1.0f - v;
            public static readonly Normalizer PermanentMax = v => 1.0f;
        }

        protected readonly MoveImpactInfos ImpactInfos;
        protected readonly Bounds Bounds;
        protected readonly float WanderPeriod;

        public readonly List<Transform> Dangers = new List<Transform>();
        public readonly List<Transform> Preys = new List<Transform>();
        public readonly List<Transform> Friends = new List<Transform>();

        protected Vector3 WanderDirection = Vector3.right;

        public AnimalMover(
            [FromThisObject] Transform movable, float maxSpeed, MoveImpactInfos impactInfos, Bounds bounds, float wanderPeriod
        ) : base(movable, maxSpeed)
        {
            ImpactInfos = impactInfos;
            Bounds = bounds;
            WanderPeriod = wanderPeriod;

            CalculateWanderDirectionAsync();
            MoveAsync();
        }

        protected virtual async Task CalculateWanderDirectionAsync()
        {
            while (IsAlive)
            {
                Vector3 oldWanderDirection = WanderDirection;
                Vector2 insideUnitCircle = Random.insideUnitCircle;
                Vector3 newWanderDirection = new Vector3(insideUnitCircle.x, 0.0f, insideUnitCircle.y).normalized;
                float t = 0;

                while (t < 1.0f && IsAlive)
                {
                    WanderDirection = Vector3.Slerp(oldWanderDirection, newWanderDirection, t);
                    
                    t += Time.deltaTime * WanderPeriod;
                    await Task.Yield();
                }

                WanderDirection = newWanderDirection;
            }
        }

        protected override void MoveFrame() => MoveFrame(Dangers, Preys, Friends);

        private void MoveFrame(
            IEnumerable<Transform> dangers, IEnumerable<Transform> preys, IEnumerable<Transform> friends
        )
        {
            Vector3 goalDirection = GetWanderingImpact();

            foreach (Transform danger in dangers)
            {
                if (danger != null)
                {
                    goalDirection += -GetImpactTo(danger.position, ImpactInfos.EscapeEnemy, Normalizers.Inverse);
                }
            }

            foreach (Transform prey in preys)
            {
                if (prey != null)
                {
                    goalDirection += GetImpactTo(prey.position, ImpactInfos.PursuePrey, Normalizers.PermanentMax);
                }
            }

            foreach (Transform friend in friends)
            {
                if (friend != null)
                {
                    goalDirection += GetImpactTo(friend.position, ImpactInfos.FollowFriend, Normalizers.Default);
                    goalDirection += -GetImpactTo(friend.position, ImpactInfos.EscapeFriend, Normalizers.Inverse);
                }
            }

            goalDirection += GetBoundsImpact(Bounds);

            Move(goalDirection);
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

        protected virtual Vector3 GetWanderingImpact()
        {
            return ImpactInfos.WanderPriority * WanderDirection;
        }

        protected Vector3 GetAveragePosition(IEnumerable<Transform> transforms)
        {
            return transforms.Select(transform => transform.position).Aggregate((p1, p2) => p1 + p2)
                 / transforms.Count();
        }
    }
}

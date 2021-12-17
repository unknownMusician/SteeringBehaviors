#nullable enable

using System;
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
        protected readonly Transform Movable;
        protected readonly float MaxSpeed;

        protected readonly SingleTokenCancellationGenerator CancellationGenerator;

        public Mover(Transform movable, float maxSpeed)
        {
            CancellationGenerator = new SingleTokenCancellationGenerator();

            Movable = movable;
            MaxSpeed = maxSpeed;
        }

        public virtual async Task MoveAsync(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                StopMoving();

                return;
            }

            await MoveAsync(() => direction);
        }

        public virtual async Task MoveToPointAsync(Vector3 worldPoint, float speedMultiplier)
            => await MoveAsync((worldPoint - Movable.position).normalized * speedMultiplier);

        public virtual async Task WalkAsync(Vector3 center, float radius, float speedMultiplier)
        {
            if (center == Movable.position)
            {
                const float error = 0.05f;
                
                center += error * Vector3.right;
            }
            
            CancellationToken cancellationToken = CancellationGenerator.New();

            while (!cancellationToken.IsCancellationRequested)
            {
                const float angle = 0.45f;

                Vector3 direction = Quaternion.Euler(0.0f, Random.Range(-angle, angle), 0.0f)
                                  * (center - Movable.position).normalized;

                direction *= speedMultiplier;

                while (Vector3.Distance(center, Movable.position) < radius)
                {
                    MoveFrame(direction);

                    await Task.Yield();
                }
            }
        }

        public virtual async Task EscapeFromAsync(Transform enemy, float safeDistance)
        {
            await MoveAsync(
                () => (Movable.position - enemy.position).normalized,
                () => Vector3.Distance(Movable.position, enemy.position) > safeDistance
            );
        }

        public virtual async Task PursueAsync(Transform prey, float lostDistance)
        {
            await MoveAsync(
                () => (prey.position - Movable.position).normalized,
                () => Vector3.Distance(Movable.position, prey.position) < lostDistance
            );
        }

        public virtual async Task PursueForAsync(Transform transform, float time)
        {
            float startTime = Time.time;

            await MoveAsync(
                () => (transform.position - Movable.position).normalized,
                () => Time.time - startTime < time
            );
        }

        public virtual async Task PursueAsync(Transform prey, float lostDistance, float time)
        {
            float startTime = Time.time;

            await MoveAsync(
                () => (prey.position - Movable.position).normalized,
                () => (Vector3.Distance(Movable.position, prey.position) < lostDistance)
                   && (Time.time - startTime < time)
            );
        }

        public virtual async Task MoveAsync(Func<Vector3> directionProvider)
            => await MoveAsync(directionProvider, () => true);

        public virtual async Task MoveAsync(Func<Vector3> directionProvider, Func<bool> moveCondition)
        {
            CancellationToken cancellationToken = CancellationGenerator.New();

            while (!cancellationToken.IsCancellationRequested && moveCondition())
            {
                MoveFrame(directionProvider());

                await Task.Yield();
            }
        }

        protected virtual void MoveFrame(Vector3 direction) => Movable.position +=
            MaxSpeed * Time.deltaTime * Vector3.ClampMagnitude(direction, 1.0f);

        public virtual void StopMoving() => CancellationGenerator.Cancel();

        public virtual void Dispose() => CancellationGenerator.Dispose();
    }
}

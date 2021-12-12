using System;
using System.Threading;
using System.Threading.Tasks;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SteeringBehaviors.Movement
{
    [GenerateMonoBehaviour]
    public sealed class MobiksMover : IMover, IDisposable
    {
        private readonly Transform Movable;

        private readonly SingleTokenCancellationGenerator CancellationGenerator;

        private CancellationToken _currentCancellationToken;

        private int _currentAngle = 0;
        private readonly ForceCalculator _forceCalculator = new ForceCalculator();

        public MobiksMover([FromThisObject] Transform movable)
        {
            CancellationGenerator = new SingleTokenCancellationGenerator();
            
            Movable = movable;
            // movable.rotation = Quaternion.LookRotation(-movable.forward);
        }
        


        private async Task MoveAsync(Func<Vector3> directionProvider, float speed)
            => await MoveAsync(directionProvider, () => true, speed);

        private async Task MoveAsync(Func<Vector3> directionProvider, Func<bool> moveCondition, float speed)
        {
            CancellationToken cancellationToken = CancellationGenerator.New();
            _currentCancellationToken = cancellationToken;

            while (!cancellationToken.IsCancellationRequested && moveCondition())
            {
                MoveFrame(directionProvider(), speed);

                await Task.Yield();
            }
        }

       


        

        private void MoveFrame(Vector3 direction, float speed) => Movable.position +=
            speed * Time.deltaTime * Vector3.ClampMagnitude(direction, 1.0f);

        public async Task PursueAsync(Transform prey, float lostDistance, float time, float pursuitSpeed)
        {
            await MoveAsync(
                () => (prey.position - Movable.position).normalized,
                () => Vector3.Distance(Movable.position, prey.position) < lostDistance
            );
        }

        


        public Task WanderWithGroupAsync(float wanderingSpeed, Transform[] @group)
        {
            throw new NotImplementedException();
        }

        public async Task EscapeFromAsync(Transform[] enemies, float safeDistance, float escapingSpeed)
        {
            CancellationToken cancellationToken = CancellationGenerator.New();

            while (!cancellationToken.IsCancellationRequested )
            {
                Vector3 escapingVelocity = _forceCalculator.GetEscapingVelocity(enemies, escapingSpeed, Movable.position);

                ApplyForces(escapingVelocity);
                
                await Task.Yield();
            }
        }

        public Task EscapeWithGroupAsync(Transform[] enemies, Transform[] @group, float safeDistance, float escapingSpeed)
        {
            throw new NotImplementedException();
        }


        public async Task WanderAsync(float wanderingSpeed)
        {
            CancellationToken cancellationToken = CancellationGenerator.New();

            while (!cancellationToken.IsCancellationRequested)
            {
                Vector3 wanderingVelocity = _forceCalculator.GetWanderingVelocity(wanderingSpeed, Movable.position,
                    Movable.forward,
                    ref _currentAngle);

                ApplyForces(wanderingVelocity);
                await Task.Yield();
            }
        }
        
        private void ApplyForces(Vector3 finallyVelocity)
        {
            Movable.position += finallyVelocity * Time.deltaTime;
            Movable.rotation = Quaternion.LookRotation(finallyVelocity.normalized);
        }

        public void Dispose()
        {
            CancellationGenerator.Cancel();

            CancellationGenerator.Dispose();
        }
        public void StopMoving() => CancellationGenerator.Cancel();

    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using SteeringBehaviors.Movement.Settings;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SteeringBehaviors.Movement
{
    [GenerateMonoBehaviour]
    public sealed class MobiksMover : IMover, IDisposable
    {
        private readonly Transform _movable;
        private readonly MovementSettings _movementSettings;

        private readonly SingleTokenCancellationGenerator _cancellationGenerator;

        private CancellationToken _currentCancellationToken;

        private int _currentAngle = 0;
        private readonly ForceCalculator _forceCalculator;

        public MobiksMover([FromThisObject] Transform movable, MovementSettings movementSettings)
        {
            _cancellationGenerator = new SingleTokenCancellationGenerator();
            
            _movementSettings = movementSettings;
            
            _forceCalculator = new ForceCalculator(_movementSettings);
            
            _movable = movable;
        }
        


        private async Task MoveAsync(Func<Vector3> directionProvider, float speed)
            => await MoveAsync(directionProvider, () => true, speed);

        private async Task MoveAsync(Func<Vector3> directionProvider, Func<bool> moveCondition, float speed)
        {
            CancellationToken cancellationToken = _cancellationGenerator.New();
            _currentCancellationToken = cancellationToken;

            while (!cancellationToken.IsCancellationRequested && moveCondition())
            {
                MoveFrame(directionProvider(), speed);

                await Task.Yield();
            }
        }

        private void MoveFrame(Vector3 direction, float speed) => _movable.position +=
            speed * Time.deltaTime * Vector3.ClampMagnitude(direction, 1.0f);

        
        
        public async Task PursueAsync(Transform prey, float lostDistance, float time, float pursuitSpeed)
        {
            await MoveAsync(
                () => (prey.position - _movable.position).normalized,
                () => Vector3.Distance(_movable.position, prey.position) < lostDistance,
                pursuitSpeed
            );
        }

     
        
        
        #region Complete

        public async Task WanderAsync(float wanderingSpeed)
        {
            CancellationToken cancellationToken = _cancellationGenerator.New();

            while (!cancellationToken.IsCancellationRequested)
            {
                Vector3 wanderingVelocity = _forceCalculator.GetWanderingVelocity(wanderingSpeed, _movable.position,
                    _movable.forward,
                    ref _currentAngle);

                ApplyForces(wanderingVelocity);
                await Task.Yield();
            }
        }
        public async Task WanderWithGroupAsync(float wanderingSpeed, Transform[] group)
        {
            CancellationToken cancellationToken = _cancellationGenerator.New();

            while (!cancellationToken.IsCancellationRequested)
            {
                Vector3 wanderingVelocity =
                    _forceCalculator.GetWanderingWithGroupVelocity(_movable, group, ref _currentAngle, wanderingSpeed);

                ApplyForces(wanderingVelocity);
                await Task.Yield();
            }
        }
        
        public async Task EscapeFromAsync(Transform[] enemies, float safeDistance, float escapingSpeed)
        {
            CancellationToken cancellationToken = _cancellationGenerator.New();

            while (!cancellationToken.IsCancellationRequested )
            {
                Vector3 escapingVelocity = _forceCalculator.GetEscapingVelocity(_movable, enemies, escapingSpeed);

                ApplyForces(escapingVelocity);
                
                await Task.Yield();
            }
        }
        public async Task EscapeWithGroupAsync(Transform[] enemies, Transform[] group, float safeDistance,
            float escapingSpeed)
        {
            CancellationToken cancellationToken = _cancellationGenerator.New();

            
            while (!cancellationToken.IsCancellationRequested )
            {
                Vector3 escapingVelocity = _forceCalculator.GetEscapingWithGroupVelocity(_movable,
                    enemies, 
                    group,
                    escapingSpeed);

                ApplyForces(escapingVelocity);
                
                await Task.Yield();
            }
        }
        
        
        
        private void ApplyForces(Vector3 finallyVelocity)
        {
            _movable.position += finallyVelocity * Time.deltaTime;
            _movable.rotation = Quaternion.LookRotation(finallyVelocity.normalized);
        }
        public void Dispose()
        {
            _cancellationGenerator.Cancel();

            _cancellationGenerator.Dispose();
        }
        public void StopMoving() => _cancellationGenerator.Cancel();

        #endregion

    }
}
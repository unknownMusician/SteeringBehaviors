using System;
using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Animals.Wolf.States;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Animals.Wolf
{
    [GenerateMonoBehaviour]
    public sealed class Wolf : IDisposable
    {
        private readonly AnimalState _wanderingState;
        private readonly AnimalState _pursuitState;

        private AnimalState _currentState;
        private AnimalState _lastState;
        private bool _isAlive = true;
        private readonly AnimalInfo _animalInfo;
        private readonly WolfSettings _wolfSettings;
        
        public Wolf(
            [Inject(typeof(Mover))] IMover mover,
            [FromThisObject] Transform transform,
            WolfSettings wolfSettings) 
        {
            _animalInfo = new AnimalInfo(mover, transform);
            _wolfSettings = wolfSettings;
            
            _wanderingState = new WanderingState(_animalInfo, wolfSettings);
            _pursuitState = new PursuitState(_animalInfo, wolfSettings);
            _lastState = _currentState = _wanderingState;

            // _currentState.StartMoving();
            SeekForVictims();
        }
        
        private async Task SeekForVictims()
        {
            while (_isAlive)
            {
                _currentState = TryFindVictims(out _animalInfo.EnemiesTransforms) ? _pursuitState : _wanderingState;
                // if (_currentState.Equals(_lastState))
                // {
                //     await Task.Yield();
                // }
                //
                // _lastState = _currentState;
                _currentState.StartMoving();
                await Task.Yield();
            }
        }
        
        //todo resolve layerMask to int problem
        private bool TryFindVictims(out Transform[] enemies)
        {
            enemies = Physics.OverlapSphere(
                    _animalInfo.AnimalTransform.position, 
                    _wolfSettings.DetectionRadius,
                    _wolfSettings.EnemiesLayers.value)
                .Select(collider => collider.transform)
                .ToArray();
            return enemies.Any();
        }

        public void Dispose() => _isAlive = false;
    }
}
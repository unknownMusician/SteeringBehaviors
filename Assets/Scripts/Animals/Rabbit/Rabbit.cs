using System;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.Animals.Rabbit.States;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace SteeringBehaviors.Animals.Rabbit
{
    [GenerateMonoBehaviour]
    public sealed class Rabbit : IDisposable
    {
        private readonly AnimalState<AnimalInfo> _wanderingState;
        private readonly AnimalState<AnimalInfo> _escapingState;

        private AnimalState<AnimalInfo> _currentState;
        private AnimalState<AnimalInfo> _lastState;
        private bool _isAlive = true;
        private readonly AnimalInfo _animalInfo;
        private readonly RabbitSettings _rabbitSettings;
        
        public Rabbit(
            [Inject(typeof(MobiksMover))] IMover mover,
            [FromThisObject] Transform transform,
            RabbitSettings rabbitSettings)
        {
            _animalInfo = new AnimalInfo(mover, transform);
            _rabbitSettings = rabbitSettings;
            
            _wanderingState = new WanderingState(_animalInfo, rabbitSettings);
            _escapingState = new EscapingState(_animalInfo, rabbitSettings);
            _lastState = _currentState = _wanderingState;

            SeekForEnemies();
            // _currentState.StartMoving();
        }
        private async Task SeekForEnemies()
        {
            while (_isAlive)
            {
                _currentState = TryFindEnemies(out _animalInfo.EnemiesTransforms) ? _escapingState : _wanderingState;
                // if (_currentState.Equals(_lastState))
                // {
                //     await Task.Yield();
                //     continue;
                // }

                // Debug.Log("CHANGE STATE");
                // _lastState = _currentState;
                _currentState.StartMoving();

                await Task.Yield();
            }
        }

        private bool TryFindEnemies(out Transform[] enemies)
        {
            enemies = Physics.OverlapSphere(
                    _animalInfo.AnimalTransform.position,
                    _rabbitSettings.DetectionRadius)
                .Select(collider => collider.transform)
                .Where(transform => transform != _animalInfo.AnimalTransform)
                .ToArray();
            return enemies.Any();
        }

        public void Dispose() => _isAlive = false;
    }
}
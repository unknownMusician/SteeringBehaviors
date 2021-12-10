using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.Animals.Rabbit.States;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Animals.Rabbit
{
    public sealed class Rabbit
    {
        private readonly AnimalState _wanderingState;
        private readonly AnimalState _escapingState;

        private AnimalState _currentState;
        private AnimalState _lastState;
        private bool _isAlive = true;
        private readonly AnimalInfo _animalInfo;
        private readonly RabbitSettings _rabbitSettings;

        
        public Rabbit(
            [FromThisObject] IMover mover,
            [FromThisObject] Transform transform,
            RabbitSettings rabbitSettings)
        {
            _animalInfo = new AnimalInfo(mover, transform);
            _rabbitSettings = rabbitSettings;
            
            _wanderingState = new WanderingState(_animalInfo, rabbitSettings);
            _escapingState = new EscapingState(_animalInfo, rabbitSettings);
            _lastState = _currentState = _wanderingState;

            SeekForEnemies();
        }
        private async Task SeekForEnemies()
        {
            while (_isAlive)
            {
                _currentState = TryFindEnemies(out _animalInfo.EnemiesTransforms) ? _escapingState : _wanderingState;
                if (_currentState.Equals(_lastState))
                {
                    continue;
                }

                _lastState = _currentState;
                _currentState.StartMoving();

                await Task.Yield();
            }
        }

        private bool TryFindEnemies(out Transform[] enemies)
        {
            enemies = Physics.OverlapSphere(
                    _animalInfo.AnimalTransform.position,
                    _rabbitSettings.RabbitDetectionRadius)
                .Select(collider => collider.transform)
                .ToArray();
            return enemies.Any();
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.Animals.States;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Animals.Animals
{
    public sealed class Rabbit : Animal
    {
        private readonly IState _wanderingState;
        private readonly IState _escapingState;

        private IState _currentState;
        private IState _lastState;
        private bool _isAlive = true;


        public Rabbit(
            [FromThisObject] IMover mover,
            [FromThisObject] Transform transform,
            AnimalsBehaviourSettings animalsBehaviourSettings)
            : base(
                new AnimalInfo(
                    mover,
                    transform,
                    new AnimalBehaviourSettings(
                        animalsBehaviourSettings.RabbitDetectionRadius,
                        animalsBehaviourSettings.RabbitDetectionLayers)))
        {
            // _animalInfo = new AnimalInfo(mover, transform, DetectionRadius);
            _wanderingState = new WanderingState(_animalInfo);
            _escapingState = new EscapingState(_animalInfo);
            _lastState = _currentState = _wanderingState;

            SeekForEnemies();
        }

        private async Task SeekForEnemies()
        {
            while (_isAlive)
            {
                _currentState = TryFindEnemies(out _animalInfo.EnemiesTransforms) ? _escapingState : _wanderingState;
                if (((AnimalState) _currentState).Equals(_lastState))
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
                    _animalInfo.AnimalBehaviourSettings.AnimalDetectionRadius)
                .Select(collider => collider.transform)
                .ToArray();
            return enemies.Any();
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.Animals.Deer.States;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Animals.Deer
{
    public sealed class Deer
    {
        private readonly AnimalState _wanderingState;
        private readonly AnimalState _escapingState;

        private AnimalState _currentState;
        private AnimalState _lastState;
        private bool _isAlive = true;
        private readonly AnimalInfo _animalInfo;
        private readonly DeerSettings _deerSettings;

        public Deer(
            [FromThisObject] IMover mover, 
            [FromThisObject] Transform transform,
            DeerSettings deerSettings)
        {
            _animalInfo = new AnimalInfo(mover, transform);
            _deerSettings = deerSettings;
            
            _wanderingState = new WanderingState(_animalInfo, deerSettings);
            _escapingState = new EscapingState(_animalInfo, deerSettings);
            _lastState = _currentState = _wanderingState;
                
            SeekForEnemies();
        }
        
        private async Task SeekForEnemies()
        {
            while (_isAlive)
            {
                _currentState = TryFindEntities(out _animalInfo.EnemiesTransforms) ? _escapingState : _wanderingState;
                if (_currentState.Equals(_lastState))
                {
                    continue;
                }

                _lastState = _currentState;
                _currentState.StartMoving();

                await Task.Yield();
            }
        }
        
        private bool TryFindEntities(out Transform[] enemies)
        {
            enemies = Physics.OverlapSphere(
                    _animalInfo.AnimalTransform.position, 
                    _deerSettings.DeerDetectionRadius)
                .Select(collider => collider.transform)
                .ToArray();
            return enemies.Any();
        }
    }
}
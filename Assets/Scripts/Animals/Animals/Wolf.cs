using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.Animals.States;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Animals.Animals
{
    public sealed class Wolf : Animal
    {
        private readonly IState _wanderingState;
        private readonly IState _pursuitState;

        private IState _currentState;
        private IState _lastState;
        private bool _isAlive = true;
        
        public Wolf(
            [FromThisObject] IMover mover, 
            [FromThisObject] Transform transform,
            AnimalsBehaviourSettings animalsBehaviourSettings) 
            : base(new AnimalInfo(
                mover, transform, new AnimalBehaviourSettings(
                    animalsBehaviourSettings.WolfDetectionRadius, 
                    animalsBehaviourSettings.WolfDetectionLayers)))
        {
            _wanderingState = new WanderingState(_animalInfo);
            _pursuitState = new PursuitState(_animalInfo, animalsBehaviourSettings.WolfPursueTime);

            _lastState = _currentState = _wanderingState;

            SeekForVictims();
        }
        
        private async Task SeekForVictims()
        {
            while (_isAlive)
            {
                _currentState = TryFindVictims(out _animalInfo.EnemiesTransforms) ? _pursuitState : _wanderingState;
                if (((AnimalState)_currentState).Equals(_lastState))
                {
                    continue;
                }

                _lastState = _currentState;
                _currentState.StartMoving();

                await Task.Yield();
            }
        }
        
        //todo resolve layerMask to int problem
        private bool TryFindVictims(out Transform[] enemies)
        {
            enemies = Physics.OverlapSphere(
                    _animalInfo.AnimalTransform.position, 
                    _animalInfo.AnimalBehaviourSettings.AnimalDetectionRadius, 
                    _animalInfo.AnimalBehaviourSettings.AnimalDetectionLayers.value )
                .Select(collider => collider.transform)
                .ToArray();
            return enemies.Any();
        }
    }
}
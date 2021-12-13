using System;
using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.Animals.Deer.States;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Animals.Deer
{
    [GenerateMonoBehaviour]
    public sealed class Deer : IDisposable
    {
        private readonly AnimalState<GroupAnimalInfo> _wanderingState;
        private readonly AnimalState<GroupAnimalInfo> _escapingState;

        private AnimalState<GroupAnimalInfo> _currentState;
        private AnimalState<GroupAnimalInfo> _lastState;
        private bool _isAlive = true;
        private readonly GroupAnimalInfo _animalInfo;
        private readonly DeerSettings _deerSettings;

        public Deer(
            [Inject(typeof(MobiksMover))] IMover mover,
            [FromThisObject] Transform transform,
            DeerSettings deerSettings)
        {
            _animalInfo = new GroupAnimalInfo(mover, transform);
            _deerSettings = deerSettings;
            
            _wanderingState = new WanderingState(_animalInfo, deerSettings);
            _escapingState = new EscapingState(_animalInfo, deerSettings);
            _lastState = _currentState = _wanderingState;
                
            SeekForEntities();
        }
        
        private async Task SeekForEntities()
        {
            while (_isAlive)
            {
                FindFriends(out _animalInfo.FriendsTransforms);
                _currentState = TryFindEnemies(out _animalInfo.EnemiesTransforms) ? _escapingState : _wanderingState;
                // if (_currentState.Equals(_lastState))
                // {
                //     continue;
                // }
                //
                // _lastState = _currentState;
                
                _currentState.StartMoving();
                await Task.Yield();
            }
        }
        
        private bool TryFindEnemies(out Transform[] enemies)
        {
            enemies = Physics.OverlapSphere(
                    _animalInfo.AnimalTransform.position, 
                    _deerSettings.DetectionRadius,
                    _deerSettings.EnemiesLayers)
                .Select(collider => collider.transform)
                .ToArray();
            
            return enemies.Any();
        }
        
        private void FindFriends(out Transform[] nearestDeer)
        {
            nearestDeer = Physics.OverlapSphere(
                    _animalInfo.AnimalTransform.position, 
                    _deerSettings.CohesionRadius,
                    _deerSettings.DeerGroupLayers)
                .Select(collider => collider.transform)
                .Where(transform => transform != _animalInfo.AnimalTransform)
                .ToArray();
            // return nearestDeer.Any();
        }

        public void Dispose() => _isAlive = false;
    }
}
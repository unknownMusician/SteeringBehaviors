using UnityEngine;

namespace SteeringBehaviors.Animals.States
{
    public class PursuitState : AnimalState, IState
    {
        private readonly float _maxPursuitTime;
        public PursuitState(AnimalInfo animalInfo, float maxPursuitTime) : base(animalInfo)
        {
            _maxPursuitTime = maxPursuitTime;
        }
        
        public override void StartMoving()
        {
            Transform firstVictim = AnimalInfo.EnemiesTransforms[0];
            AnimalInfo.Mover.Pursue(
                firstVictim, 
                AnimalInfo.AnimalBehaviourSettings.AnimalDetectionRadius,
                _maxPursuitTime);
        }
    }
}
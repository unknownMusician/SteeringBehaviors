using System;

namespace SteeringBehaviors.Animals.States
{
    public abstract class AnimalState : IState
    {
        protected readonly AnimalInfo AnimalInfo;
        
        protected AnimalState(AnimalInfo animalInfo)
        {
            AnimalInfo = animalInfo;
        }
        public abstract void StartMoving();

        public bool Equals(AnimalState otherAnimalState)
        {
            return AnimalInfo.EnemiesTransforms == otherAnimalState.AnimalInfo.EnemiesTransforms;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is AnimalState other))
            {
                throw new InvalidCastException("Cannot cast 'object' to 'AnimalState'");
            }
            return AnimalInfo.EnemiesTransforms.Equals(other.AnimalInfo.EnemiesTransforms);
        }
    }
}
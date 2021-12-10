using System;

namespace SteeringBehaviors.Animals
{
    public abstract class AnimalState
    {
        protected readonly AnimalInfo AnimalInfo;
        
        protected AnimalState(AnimalInfo animalInfo)
        {
            AnimalInfo = animalInfo;
        }
        
        public abstract void StartMoving();

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
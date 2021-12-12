using System;

namespace SteeringBehaviors.Animals
{
    public abstract class AnimalState<TInfo> where TInfo : AnimalInfo
    {
        protected readonly TInfo AnimalInfo;

        protected AnimalState(TInfo animalInfo)
        {
            AnimalInfo = animalInfo;
        }
        
        public abstract void StartMoving();

        public override bool Equals(object obj)
        {
            if (!(obj is AnimalState<TInfo> other))
            {
                throw new InvalidCastException("Cannot cast 'object' to 'AnimalState'");
            }

            for (int i = 0; i < AnimalInfo.EnemiesTransforms.Length; i++)
            {
                if ((int)AnimalInfo.EnemiesTransforms[i].position.x != (int)other.AnimalInfo.EnemiesTransforms[i].position.x)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
using UnityEngine;

namespace SteeringBehaviors.Animals.Animals
{
    public abstract class Animal
    {
        protected readonly AnimalInfo _animalInfo;

        protected Animal(AnimalInfo animalInfo)
        {
            _animalInfo = animalInfo;
        }
    }
}
using System;
using System.Threading.Tasks;
using SteeringBehaviors.Movement;
using UnityEngine;

namespace SteeringBehaviors.Animals
{
    public abstract class Animal<TSettings> : IDisposable
    {
        protected bool IsAlive = true;
        protected readonly AnimalInfo AnimalInfo;
        protected readonly TSettings AnimalSettings;

        protected Animal(
            AnimalMover mover,
            Transform transform,
            TSettings animalSettings)
        {
            AnimalInfo = new AnimalInfo(mover, transform);
            AnimalSettings = animalSettings;

            SeekForEntities();
        }

        protected abstract Task SeekForEntities();

        public void Dispose() => IsAlive = false;
    }
}
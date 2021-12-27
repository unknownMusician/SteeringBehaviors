#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SteeringBehaviors.Movement
{
    public abstract class Mover : IDisposable
    {
        protected readonly Transform Movable;
        protected readonly float MaxSpeed;
        
        protected bool IsAlive = true;

        protected Mover(Transform movable, float maxSpeed)
        {
            Movable = movable;
            MaxSpeed = maxSpeed;
        }

        protected virtual async Task MoveAsync()
        {
            while (IsAlive)
            {
                MoveFrame();

                await Task.Yield();
            }
        }

        protected abstract void MoveFrame();

        protected virtual void Move(Vector3 direction)
        {
            Movable.position += MaxSpeed * Time.deltaTime * Vector3.ClampMagnitude(direction, 1.0f);

            if (direction != Vector3.zero)
            {
                Movable.rotation = Quaternion.LookRotation(direction, Vector3.up);
            }
        }

        public virtual void Dispose() => IsAlive = false;
    }
}

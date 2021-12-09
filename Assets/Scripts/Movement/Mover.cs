using System;
using System.Threading.Tasks;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Movement
{
    [GenerateMonoBehaviour]
    public class Mover : IDisposable
    {
        protected readonly Transform Movable;
        protected readonly float MaxSpeed;
        protected bool IsMoving = false;
        protected Vector3 Direction;

        public Mover(Transform movable, float maxSpeed, Mover mover)
        {
            Movable = movable;
            MaxSpeed = maxSpeed;
        }

        public virtual async Task StartMoving(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                StopMoving();
            }
            
            Direction = Vector3.ClampMagnitude(direction, 1.0f);

            if (IsMoving)
            {
                return;
            }
            
            IsMoving = true;

            while (IsMoving)
            {
                Movable.position += MaxSpeed * Time.deltaTime * Direction;

                await Task.Yield();
            }
        }

        public virtual void StopMoving() => IsMoving = false;
        public void Dispose() { }
    }

    public interface IMover
    {
        Task StartMoving(Vector3 direction);
        Task StartMovingToPoint(Vector3 worldPoint);
        Task StartWalking(Vector3 center, float radius);
        Task StartEscapingFrom(Transform transform, float safeDistance);
        Task Pursue(Transform transform, float lostDistance);
        Task PursueWithTime(Transform transform, float time);
        Task Pursue(Transform transform, float lostDistance, float time);
    }
}

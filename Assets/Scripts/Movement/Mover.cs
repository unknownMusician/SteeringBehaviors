using System.Threading.Tasks;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Movement
{
    [GenerateMonoBehaviour]
    public class Mover
    {
        protected readonly Transform Movable;
        protected readonly float MaxSpeed;
        protected bool IsMoving = false;
        protected Vector3 Direction;
        
        
        public Mover(Transform movable, float maxSpeed)
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
    }

    // public sealed class MoverComponent : MonoBehaviour
    // {
    //     [SerializeField] private float _maxSpeed;
    //     
    //     public Mover Mover { get; private set; }
    //
    //     private void Awake()
    //     {
    //         Mover = new Mover(transform, _maxSpeed);
    //     }
    //
    //     public async Task StartMoving(Vector2 direction) => await Mover.StartMoving(direction);
    //     public void StopMoving() => Mover.StopMoving();
    // }
}

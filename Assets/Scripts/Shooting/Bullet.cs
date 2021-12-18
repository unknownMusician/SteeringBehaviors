using SteeringBehaviors.SourceGeneration;
using System.Threading.Tasks;
using UnityEngine;

namespace SteeringBehaviors.Shooting
{
    [GenerateMonoBehaviour]
    public class Bullet : System.IDisposable
    {
        protected readonly GameObject GameObject;
        protected readonly Transform Transform;
        protected readonly Rigidbody Rigidbody;
        protected readonly float Velocity;

        protected bool IsAlive;

        public Bullet(GameObject gameObject, Transform transform, Rigidbody rigidbody, float velocity)
        {
            GameObject = gameObject;
            Transform = transform;
            Rigidbody = rigidbody;
            Velocity = velocity;

            MoveAsync();
        }

        protected async Task MoveAsync()
        {
            while (IsAlive)
            {
                Rigidbody.velocity = Velocity * Transform.forward;
                
                await Task.Yield();
            }
        }

        public void HandleCollisionEnter(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out IAnimal animal))
            {
                animal.Kill();
            }

            Object.Destroy(GameObject);
        }

        public void Dispose() => IsAlive = false;
    }
}

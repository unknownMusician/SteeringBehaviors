using SteeringBehaviors.SourceGeneration;
using System.Threading.Tasks;
using UnityEngine;

namespace SteeringBehaviors.Shooting
{
    [GenerateMonoBehaviour]
    public class Bullet : System.IDisposable, ITriggerEnterHandler
    {
        protected readonly GameObject GameObject;
        protected readonly Transform Transform;
        protected readonly Rigidbody Rigidbody;
        protected readonly float Velocity;

        protected bool IsAlive = true;

        public Bullet([FromThisObject] GameObject gameObject, [FromThisObject] Transform transform, Rigidbody rigidbody, float velocity)
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

        public void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out IAnimal animal))
            {
                animal.Kill();
            }

            Object.Destroy(GameObject);
        }

        public void Dispose() => IsAlive = false;
    }
}

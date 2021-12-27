using SteeringBehaviors.SourceGeneration;
using System.Threading.Tasks;
using Generated.SteeringBehaviors.Hunt;
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
        protected GameObject _owner;

        protected bool IsAlive = true;

        public Bullet([FromThisObject] GameObject gameObject, [FromThisObject] Transform transform, Rigidbody rigidbody, float velocity)
        {
            GameObject = gameObject;
            Transform = transform;
            Rigidbody = rigidbody;
            Velocity = velocity;

            MoveAsync();
        }

        public void Initialize(GameObject owner) => _owner = owner;

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
            if (collider.gameObject.TryGetComponent(out KillableComponent killableComponent))
            {
                killableComponent.HeldType.KillMe(_owner);
            }

            Object.Destroy(GameObject);
        }

        public void Dispose() => IsAlive = false;
    }
}

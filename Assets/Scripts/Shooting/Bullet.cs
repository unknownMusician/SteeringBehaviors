using SteeringBehaviors.SourceGeneration;
using System.Threading.Tasks;
using UnityEngine;

namespace SteeringBehaviors.Shooting
{
    [GenerateMonoBehaviour]
    public class Bullet : System.IDisposable
    {
        private readonly Rigidbody _rigidbody;
        private bool _isAlive;
        private float _velocity;
        private Transform _transform;
        private GameObject _bulletObject;

        public Bullet(Rigidbody rigidbody,float velocity, Transform transform,GameObject bulletObject)
        {
            _bulletObject = bulletObject;
            _rigidbody = rigidbody;
            _velocity = velocity;
            _transform = transform;
        }

        public void Dispose()
        {
            _isAlive = false;
        }

        private async Task MoveAsync()
        {
            while (_isAlive)
            {
                _rigidbody.velocity = _velocity * _transform.forward;
                await Task.Yield();
            }
        }

        public void HandleCollisionEnter(GameObject gameObject)
        {
         
            if(gameObject.TryGetComponent(out IAnimal animal))
            {
                animal.Kill();
            }

            Object.Destroy(_bulletObject);


        }

    }
}

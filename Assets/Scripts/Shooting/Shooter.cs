using SteeringBehaviors.SourceGeneration;
using System.Threading.Tasks;
using UnityEngine;

namespace SteeringBehaviors.Shooting
{
    [GenerateMonoBehaviour]
    public class Shooter : IShooter, System.IDisposable
    {

        private Transform _transform;
        private bool _isAlive;
        private bool _isAiming;
        private GameObject _bullet;
        private Vector3 _offset;
        private readonly IMagazine _magazine;
        public Vector3 AimPosition { set; protected get; }


        public Shooter(Transform transform, GameObject bullet, Vector3 offset,IMagazine magazine)
        {
            _offset = offset;
            _transform = transform;
            _bullet = bullet;
            _magazine = magazine;
        }

        private async Task AimAsync()
        {
            while (_isAlive)
            {
                if (_isAiming)
                {
                    _transform.rotation = Quaternion.LookRotation(AimPosition - _transform.position);
                }
                await Task.Yield();
            }
        }

        public void StartAiming()
        {
            _isAiming = true;
        }

        public void StopAiming()
        {
            _isAiming = false;
        }

        public void TryShoot()
        {
            GameObject bulletInstance = Object.Instantiate(_bullet);
            bulletInstance.transform.position = _transform.position + _offset;
            bulletInstance.transform.rotation = _transform.rotation;
        }

        public void Dispose()
        {
            _isAlive = false;
        }

        public void TryReload()
        {
            
        }
    }
}


#nullable enable

using SteeringBehaviors.SourceGeneration;
using System.Threading.Tasks;
using UnityEngine;

namespace SteeringBehaviors.Shooting
{
    [GenerateMonoBehaviour]
    public class Shooter : IShooter, System.IDisposable
    {
        protected readonly Transform Transform;
        protected readonly GameObject BulletPrefab;
        protected readonly Vector3 Offset;
        protected readonly IMagazine Magazine;

        protected bool IsAlive;
        protected bool IsAiming;

        public Vector3 AimPosition { set; protected get; }

        public Shooter(Transform transform, GameObject bulletPrefab, Vector3 offset, IMagazine magazine)
        {
            Transform = transform;
            BulletPrefab = bulletPrefab;
            Offset = offset;
            Magazine = magazine;

            AimAsync();
        }

        protected async Task AimAsync()
        {
            while (IsAlive)
            {
                if (IsAiming)
                {
                    Transform.rotation = Quaternion.LookRotation(AimPosition - Transform.position);
                }

                await Task.Yield();
            }
        }

        public void StartAiming() => IsAiming = true;
        public void StopAiming() => IsAiming = false;

        public void TryShoot()
        {
            GameObject bullet = Object.Instantiate(BulletPrefab);

            bullet.transform.SetPositionAndRotation(Transform.position + Offset, Transform.rotation);
        }

        public void TryReload() => Magazine.ReloadWeapon();

        public void Dispose() => IsAlive = false;
    }
}

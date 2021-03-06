#nullable enable

using SteeringBehaviors.SourceGeneration;
using System;
using System.Threading.Tasks;
using Generated.SteeringBehaviors.Shooting;
using UnityEngine;

namespace SteeringBehaviors.Shooting
{
    [GenerateMonoBehaviour]
    public class Shooter : IShooter, System.IDisposable
    {
        protected readonly Transform Transform;
        protected readonly GameObject BulletPrefab;
        protected readonly Vector3 Offset;
        public readonly IMagazine Magazine;
        public event Action? OnShot;
        public event Action? OnReload;

        protected bool IsAlive = true;
        protected bool IsAiming;

        public Vector3 AimPosition { set; protected get; }

        public Shooter([FromThisObject] Transform transform, GameObject bulletPrefab, Vector3 offset, [Inject(typeof(Magazine))] IMagazine magazine)
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
                    Vector3 lookDirection = AimPosition - Transform.position;
                    
                    Transform.rotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0.0f, lookDirection.z));
                }

                await Task.Yield();
            }
        }

        public void StartAiming() => IsAiming = true;
        public void StopAiming() => IsAiming = false;

        public void TryShoot()
        {
            if (Magazine.IsWeaponEmpty)
            {
                return;
            }

            GameObject bullet = UnityEngine.Object.Instantiate(BulletPrefab);
            bullet.GetComponent<BulletComponent>().HeldType.Initialize(Transform.gameObject);
            bullet.transform.SetPositionAndRotation(Transform.position + Offset, Transform.rotation);
            
            Magazine.HandleShoot(1);
            
            OnShot?.Invoke();
        }

        public void TryReload()
        {
            Magazine.ReloadWeapon();
            
            OnReload?.Invoke();
        }

        public void Dispose() => IsAlive = false;
    }
}

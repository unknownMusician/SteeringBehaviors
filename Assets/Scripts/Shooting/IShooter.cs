using UnityEngine;

#nullable enable

namespace SteeringBehaviors.Shooting
{
    public interface IShooter
    {
        Vector3 AimPosition { set; }
        
        void StartAiming();
        void StopAiming();

        void TryShoot();
    }
}

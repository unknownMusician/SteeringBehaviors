#nullable enable

namespace SteeringBehaviors.Shooting
{
    public interface IShooter
    {
        void StartAiming();
        void StopAiming();

        void TryShoot();
    }
}

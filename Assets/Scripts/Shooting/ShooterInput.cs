using System;
using SteeringBehaviors.InputHandling;
using SteeringBehaviors.SourceGeneration;
using UnityEngine.InputSystem;

namespace SteeringBehaviors.Shooting
{
    [GenerateMonoBehaviour]
    public class ShooterInput : IDisposable
    {
        protected readonly IShooter Shooter;
        protected readonly Controls Controls = new Controls();

        public ShooterInput([Inject(typeof(Shooter))] IShooter shooter)
        {
            Shooter = shooter;

            EnableControls();
        }

        protected void EnableControls()
        {
            Controls.Enable();
            
            Controls.Shooting.Aim.performed += HandleStartAiming;
            Controls.Shooting.Aim.canceled += HandleStopAiming;
            Controls.Shooting.Shoot.performed += HandleShoot;
        }

        protected void DisableControls()
        {
            Controls.Shooting.Aim.performed -= HandleStartAiming;
            Controls.Shooting.Aim.canceled -= HandleStopAiming;
            Controls.Shooting.Shoot.performed -= HandleShoot;

            Controls.Disable();
        }

        protected virtual void HandleStartAiming(InputAction.CallbackContext context) => Shooter.StartAiming();
        protected virtual void HandleStopAiming(InputAction.CallbackContext context) => Shooter.StopAiming();
        protected virtual void HandleShoot(InputAction.CallbackContext context) => Shooter.TryShoot();

        public virtual void Dispose()
        {
            DisableControls();
            Controls.Dispose();
        }
    }
}

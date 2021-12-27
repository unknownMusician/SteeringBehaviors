#nullable enable

using System;
using System.Threading.Tasks;
using SteeringBehaviors.InputHandling;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SteeringBehaviors.Shooting
{
    [GenerateMonoBehaviour]
    public class ShooterInput : IDisposable
    {
        protected readonly IShooter Shooter;
        protected readonly Controls Controls = new Controls();

        protected bool IsAlive = true;

        public ShooterInput([Inject(typeof(Shooter))] IShooter shooter)
        {
            Shooter = shooter;

            EnableControls();
            ReadMousePositionAsync();
        }

        protected async Task ReadMousePositionAsync()
        {
            while (IsAlive)
            {
                ReadMousePosition();

                await Task.Yield();
            }
        }

        protected void ReadMousePosition()
        {
            Camera? camera = Camera.main;

            if (camera == null)
            {
                throw new ArgumentException("MainCamera should not be Null.");
            }

            Ray lookRay = camera.ScreenPointToRay(Controls.Shooting.MousePosition.ReadValue<Vector2>());

            if (Physics.Raycast(lookRay, out RaycastHit hit))
            {
                Shooter.AimPosition = hit.point;
            }
        }

        protected void EnableControls()
        {
            Controls.Enable();

            Controls.Shooting.Aim.performed += HandleStartAiming;
            Controls.Shooting.Aim.canceled += HandleStopAiming;
            Controls.Shooting.Shoot.performed += HandleShoot;
            Controls.Shooting.Reload.performed += HandleReload;
        }

        protected void DisableControls()
        {
            Controls.Shooting.Aim.performed -= HandleStartAiming;
            Controls.Shooting.Aim.canceled -= HandleStopAiming;
            Controls.Shooting.Shoot.performed -= HandleShoot;
            Controls.Shooting.Reload.performed -= HandleReload;

            Controls.Disable();
        }

        protected virtual void HandleStartAiming(InputAction.CallbackContext context) => Shooter.StartAiming();
        protected virtual void HandleStopAiming(InputAction.CallbackContext context) => Shooter.StopAiming();
        protected virtual void HandleShoot(InputAction.CallbackContext context) => Shooter.TryShoot();
        protected virtual void HandleReload(InputAction.CallbackContext context) => Shooter.TryReload();

        public virtual void Dispose()
        {
            DisableControls();
            Controls.Dispose();
            IsAlive = false;
        }
    }
}

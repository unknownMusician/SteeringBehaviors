using System;
using SteeringBehaviors.InputHandling;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SteeringBehaviors.Movement
{
    [GenerateMonoBehaviour]
    public class PlayerMoverInput : IDisposable
    {
        protected readonly Controls Controls = new Controls();
        protected readonly IPlayerMover Mover;

        public PlayerMoverInput([Inject(typeof(PlayerMover))] IPlayerMover mover)
        {
            Mover = mover;
            
            Controls.Moving.Move.Enable();

            Controls.Moving.Move.performed += HandleMove;
            Controls.Moving.Move.canceled += HandleMove;
        }

        protected virtual void HandleMove(InputAction.CallbackContext context)
        {
            Vector2 direction = context.ReadValue<Vector2>();

            Mover.Direction = new Vector3(direction.x, 0.0f, direction.y);
        }

        public void Dispose()
        {
            Controls.Moving.Move.performed -= HandleMove;
            Controls.Moving.Move.canceled -= HandleMove;
            
            Controls.Moving.Move.Disable();
            
            Controls.Dispose();
        }
    }
}

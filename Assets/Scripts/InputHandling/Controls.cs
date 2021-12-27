// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace SteeringBehaviors.InputHandling
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Shooting"",
            ""id"": ""9218e28b-cc4a-458a-8012-4b58f6556bc2"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""bd5e95b0-8486-479e-9a11-d715eaf31ee9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""2565ad79-86b2-459b-b4f2-cc67a622cdcc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""e20b7871-eaef-4396-9092-75b65ef3cdb7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""3cc90b18-002e-4196-86bd-ba7967d6f7d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""59a0be7c-e6a6-4817-b20f-3cd906ede45b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2a03455-7852-4297-baf1-5ba483f42c87"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""137a0ed8-0e47-495d-821d-649e651553fc"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ca50e38-75f8-47d6-93ff-cc6914b9952f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Moving"",
            ""id"": ""a34999f6-37fa-409b-8d58-972468028d49"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c6d4791f-9cb0-4f39-a807-ae34d757c76e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6c738635-e710-48c3-a9d1-f1768bea1cb2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5c2b5dba-cc35-4645-aa37-a7827df37107"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ff1099ae-f55c-414d-a8f9-d74b59baadd9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b4068a99-4e3d-4dd6-ab8b-036d306e1324"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e1854ffb-8f10-40ce-8dd3-a7092c3ca035"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""74e521a5-9aba-441d-8b9e-42ad73b67bf0"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Shooting
            m_Shooting = asset.FindActionMap("Shooting", throwIfNotFound: true);
            m_Shooting_Aim = m_Shooting.FindAction("Aim", throwIfNotFound: true);
            m_Shooting_Shoot = m_Shooting.FindAction("Shoot", throwIfNotFound: true);
            m_Shooting_MousePosition = m_Shooting.FindAction("MousePosition", throwIfNotFound: true);
            m_Shooting_Reload = m_Shooting.FindAction("Reload", throwIfNotFound: true);
            // Moving
            m_Moving = asset.FindActionMap("Moving", throwIfNotFound: true);
            m_Moving_Move = m_Moving.FindAction("Move", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Shooting
        private readonly InputActionMap m_Shooting;
        private IShootingActions m_ShootingActionsCallbackInterface;
        private readonly InputAction m_Shooting_Aim;
        private readonly InputAction m_Shooting_Shoot;
        private readonly InputAction m_Shooting_MousePosition;
        private readonly InputAction m_Shooting_Reload;
        public struct ShootingActions
        {
            private @Controls m_Wrapper;
            public ShootingActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Aim => m_Wrapper.m_Shooting_Aim;
            public InputAction @Shoot => m_Wrapper.m_Shooting_Shoot;
            public InputAction @MousePosition => m_Wrapper.m_Shooting_MousePosition;
            public InputAction @Reload => m_Wrapper.m_Shooting_Reload;
            public InputActionMap Get() { return m_Wrapper.m_Shooting; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ShootingActions set) { return set.Get(); }
            public void SetCallbacks(IShootingActions instance)
            {
                if (m_Wrapper.m_ShootingActionsCallbackInterface != null)
                {
                    @Aim.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAim;
                    @Aim.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAim;
                    @Aim.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAim;
                    @Shoot.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
                    @Shoot.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
                    @Shoot.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
                    @MousePosition.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnMousePosition;
                    @Reload.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnReload;
                    @Reload.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnReload;
                    @Reload.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnReload;
                }
                m_Wrapper.m_ShootingActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Aim.started += instance.OnAim;
                    @Aim.performed += instance.OnAim;
                    @Aim.canceled += instance.OnAim;
                    @Shoot.started += instance.OnShoot;
                    @Shoot.performed += instance.OnShoot;
                    @Shoot.canceled += instance.OnShoot;
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                    @Reload.started += instance.OnReload;
                    @Reload.performed += instance.OnReload;
                    @Reload.canceled += instance.OnReload;
                }
            }
        }
        public ShootingActions @Shooting => new ShootingActions(this);

        // Moving
        private readonly InputActionMap m_Moving;
        private IMovingActions m_MovingActionsCallbackInterface;
        private readonly InputAction m_Moving_Move;
        public struct MovingActions
        {
            private @Controls m_Wrapper;
            public MovingActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Moving_Move;
            public InputActionMap Get() { return m_Wrapper.m_Moving; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MovingActions set) { return set.Get(); }
            public void SetCallbacks(IMovingActions instance)
            {
                if (m_Wrapper.m_MovingActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnMove;
                }
                m_Wrapper.m_MovingActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                }
            }
        }
        public MovingActions @Moving => new MovingActions(this);
        public interface IShootingActions
        {
            void OnAim(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
            void OnMousePosition(InputAction.CallbackContext context);
            void OnReload(InputAction.CallbackContext context);
        }
        public interface IMovingActions
        {
            void OnMove(InputAction.CallbackContext context);
        }
    }
}

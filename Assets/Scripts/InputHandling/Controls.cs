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
        public struct ShootingActions
        {
            private @Controls m_Wrapper;
            public ShootingActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Aim => m_Wrapper.m_Shooting_Aim;
            public InputAction @Shoot => m_Wrapper.m_Shooting_Shoot;
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
                }
            }
        }
        public ShootingActions @Shooting => new ShootingActions(this);
        public interface IShootingActions
        {
            void OnAim(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
        }
    }
}

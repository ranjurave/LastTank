// GENERATED AUTOMATICALLY FROM 'Assets/Utilities/TankControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TankControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TankControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TankControls"",
    ""maps"": [
        {
            ""name"": ""Tank"",
            ""id"": ""facc7d1c-4ab8-4ece-9149-5ccf466f7527"",
            ""actions"": [
                {
                    ""name"": ""TankMove"",
                    ""type"": ""Value"",
                    ""id"": ""635d034a-6886-4e24-8592-ae4362702998"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TankBarrel"",
                    ""type"": ""Value"",
                    ""id"": ""3f593670-486b-4ae4-aef5-493fa7ab5b20"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2a7bc4bd-c542-4727-bfac-a5242d228fb7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TankMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2291b8a2-27ca-4f9c-85cc-e5c53c7fc594"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TankMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a6047ab4-90f5-47c2-a65c-54b728c5c1df"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TankMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""22b6761f-7fa6-4f45-b07e-fb045f18c22b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TankMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""816b0bbe-b12c-47a1-84c4-fd19b0d34c3a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TankMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""084529be-fc60-43d6-a772-11a5d398e906"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TankMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""34f93d37-5866-40cc-a8f0-14b93aa1c6d2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TankBarrel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Tank
        m_Tank = asset.FindActionMap("Tank", throwIfNotFound: true);
        m_Tank_TankMove = m_Tank.FindAction("TankMove", throwIfNotFound: true);
        m_Tank_TankBarrel = m_Tank.FindAction("TankBarrel", throwIfNotFound: true);
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

    // Tank
    private readonly InputActionMap m_Tank;
    private ITankActions m_TankActionsCallbackInterface;
    private readonly InputAction m_Tank_TankMove;
    private readonly InputAction m_Tank_TankBarrel;
    public struct TankActions
    {
        private @TankControls m_Wrapper;
        public TankActions(@TankControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TankMove => m_Wrapper.m_Tank_TankMove;
        public InputAction @TankBarrel => m_Wrapper.m_Tank_TankBarrel;
        public InputActionMap Get() { return m_Wrapper.m_Tank; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TankActions set) { return set.Get(); }
        public void SetCallbacks(ITankActions instance)
        {
            if (m_Wrapper.m_TankActionsCallbackInterface != null)
            {
                @TankMove.started -= m_Wrapper.m_TankActionsCallbackInterface.OnTankMove;
                @TankMove.performed -= m_Wrapper.m_TankActionsCallbackInterface.OnTankMove;
                @TankMove.canceled -= m_Wrapper.m_TankActionsCallbackInterface.OnTankMove;
                @TankBarrel.started -= m_Wrapper.m_TankActionsCallbackInterface.OnTankBarrel;
                @TankBarrel.performed -= m_Wrapper.m_TankActionsCallbackInterface.OnTankBarrel;
                @TankBarrel.canceled -= m_Wrapper.m_TankActionsCallbackInterface.OnTankBarrel;
            }
            m_Wrapper.m_TankActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TankMove.started += instance.OnTankMove;
                @TankMove.performed += instance.OnTankMove;
                @TankMove.canceled += instance.OnTankMove;
                @TankBarrel.started += instance.OnTankBarrel;
                @TankBarrel.performed += instance.OnTankBarrel;
                @TankBarrel.canceled += instance.OnTankBarrel;
            }
        }
    }
    public TankActions @Tank => new TankActions(this);
    public interface ITankActions
    {
        void OnTankMove(InputAction.CallbackContext context);
        void OnTankBarrel(InputAction.CallbackContext context);
    }
}

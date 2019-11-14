// GENERATED AUTOMATICALLY FROM 'Assets/Prototype_Space/Scripts/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""FarmBoy"",
            ""id"": ""566e70ca-13b3-4dda-84b4-2ca708019345"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""9e8cdaa4-d413-4c5a-8894-78e5b89dafb2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Flashlight"",
                    ""type"": ""Button"",
                    ""id"": ""96a300b9-6aab-499e-8ede-7a3a30ad53b8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""7289af39-e2dd-4502-96a4-4be6e80af18d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""8d07abaf-13ed-4b3b-ba27-46f5194529e1"",
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
                    ""id"": ""d9f13e61-4b31-4c12-969f-a58e539accb3"",
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
                    ""id"": ""8fa3747b-82ce-4ffd-bea9-185110b01da1"",
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
                    ""id"": ""6ad6f1d4-0e5f-41e6-961d-ac3cf8e8d2ad"",
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
                    ""id"": ""173932a3-496a-45f5-b23f-79e3effb4ebc"",
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
                    ""id"": ""c93e61fd-c6ac-481e-b1d8-0528129352c2"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flashlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af4eafa7-4268-4396-b8e9-820871c96c24"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FarmBoy
        m_FarmBoy = asset.FindActionMap("FarmBoy", throwIfNotFound: true);
        m_FarmBoy_Move = m_FarmBoy.FindAction("Move", throwIfNotFound: true);
        m_FarmBoy_Flashlight = m_FarmBoy.FindAction("Flashlight", throwIfNotFound: true);
        m_FarmBoy_Run = m_FarmBoy.FindAction("Run", throwIfNotFound: true);
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

    // FarmBoy
    private readonly InputActionMap m_FarmBoy;
    private IFarmBoyActions m_FarmBoyActionsCallbackInterface;
    private readonly InputAction m_FarmBoy_Move;
    private readonly InputAction m_FarmBoy_Flashlight;
    private readonly InputAction m_FarmBoy_Run;
    public struct FarmBoyActions
    {
        private @Controls m_Wrapper;
        public FarmBoyActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_FarmBoy_Move;
        public InputAction @Flashlight => m_Wrapper.m_FarmBoy_Flashlight;
        public InputAction @Run => m_Wrapper.m_FarmBoy_Run;
        public InputActionMap Get() { return m_Wrapper.m_FarmBoy; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FarmBoyActions set) { return set.Get(); }
        public void SetCallbacks(IFarmBoyActions instance)
        {
            if (m_Wrapper.m_FarmBoyActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_FarmBoyActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_FarmBoyActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_FarmBoyActionsCallbackInterface.OnMove;
                @Flashlight.started -= m_Wrapper.m_FarmBoyActionsCallbackInterface.OnFlashlight;
                @Flashlight.performed -= m_Wrapper.m_FarmBoyActionsCallbackInterface.OnFlashlight;
                @Flashlight.canceled -= m_Wrapper.m_FarmBoyActionsCallbackInterface.OnFlashlight;
                @Run.started -= m_Wrapper.m_FarmBoyActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_FarmBoyActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_FarmBoyActionsCallbackInterface.OnRun;
            }
            m_Wrapper.m_FarmBoyActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Flashlight.started += instance.OnFlashlight;
                @Flashlight.performed += instance.OnFlashlight;
                @Flashlight.canceled += instance.OnFlashlight;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
            }
        }
    }
    public FarmBoyActions @FarmBoy => new FarmBoyActions(this);
    public interface IFarmBoyActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFlashlight(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
}

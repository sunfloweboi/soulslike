//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/player controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Playercontrols: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Playercontrols()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""player controls"",
    ""maps"": [
        {
            ""name"": ""Playermovement"",
            ""id"": ""7de8974e-d178-4c05-8598-fce209ffe743"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bad8010d-fa15-4f3c-99ac-6caffb2f62b8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Key"",
                    ""id"": ""6c42d25f-acfb-4658-9e87-c9a24bd922ac"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""26b207d4-9c70-4242-8f3f-a50ad68cc159"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""81ed65be-ba6a-4dd7-8f25-4c9a851fbf7c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b843e89d-6c54-4da7-b4c1-e0942cca56ae"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""663aba95-812c-4e3a-8e51-da38dc9f5df9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Playermovement
        m_Playermovement = asset.FindActionMap("Playermovement", throwIfNotFound: true);
        m_Playermovement_Movement = m_Playermovement.FindAction("Movement", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Playermovement
    private readonly InputActionMap m_Playermovement;
    private List<IPlayermovementActions> m_PlayermovementActionsCallbackInterfaces = new List<IPlayermovementActions>();
    private readonly InputAction m_Playermovement_Movement;
    public struct PlayermovementActions
    {
        private @Playercontrols m_Wrapper;
        public PlayermovementActions(@Playercontrols wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Playermovement_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Playermovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayermovementActions set) { return set.Get(); }
        public void AddCallbacks(IPlayermovementActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayermovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayermovementActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
        }

        private void UnregisterCallbacks(IPlayermovementActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
        }

        public void RemoveCallbacks(IPlayermovementActions instance)
        {
            if (m_Wrapper.m_PlayermovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayermovementActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayermovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayermovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayermovementActions @Playermovement => new PlayermovementActions(this);
    public interface IPlayermovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}

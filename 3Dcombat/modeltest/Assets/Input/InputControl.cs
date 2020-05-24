// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControl"",
    ""maps"": [
        {
            ""name"": ""PlayerControl"",
            ""id"": ""169f6f87-36a9-4c94-947a-b0f135998969"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a3fb24af-e7e8-4646-85de-4dcb05a1cd75"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7d28205b-2ccb-43f5-9c92-965c4013b88f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateCam"",
                    ""type"": ""PassThrough"",
                    ""id"": ""83304b5d-9412-4df0-8a63-fc50d33d4079"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryAttack"",
                    ""type"": ""Button"",
                    ""id"": ""ef339742-8c81-420f-b2b4-a7107dfe1a41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""a99648fc-1dd3-4f61-9b0a-0e67bafa44fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""DropWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""cda851a0-05e0-49b9-90dc-60dbdaed9454"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PickUpWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""8edcc1c7-77d1-481c-907f-4a43c158cec1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""f72970e0-d524-425e-b467-bb27d675ffae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""CallingWeaponBack"",
                    ""type"": ""Button"",
                    ""id"": ""92f04fbe-395d-48cd-8def-ac7a0d850db6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7d0bdb67-c481-4c1b-a678-9cee23312ccb"",
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
                    ""id"": ""4a96ab98-3f1d-49f6-8abd-a90e1d8ad5fd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0727a824-20da-4eb8-8884-91db2d452236"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""60559e09-c83e-4730-97be-5a1e1cfb7ce0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b5a78522-3394-4e2f-8f98-4f68e560208d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8cbe47b3-a7f6-4db6-8d30-6d68e21927b4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56cc3c35-41c3-4059-ae09-e9e0d4d34b84"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotateCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""35feb33f-03bc-497d-8f96-ef587724a7d8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCam"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4d6ae274-b561-417f-92cc-78988a125d05"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""89ddada8-91d7-4841-8bb5-d593b6292529"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""07e5b57a-4006-4735-b56f-ddf47fb2a0eb"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7da623aa-b675-430b-ae25-562416e836f0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""86c60bc5-9304-4ae5-b1cd-74430eb1b05c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96a436b6-9487-4288-a39a-61cbac76ea9d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4c2d3d2-3952-46a9-8151-c66455a83fbc"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PrimaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6d8955e-2071-4f64-a650-41125060c357"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PrimaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0ba5666-87e4-4884-ade6-0ff8cdc524f9"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PrimaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39ce6511-cbce-4bb4-9d09-e03dc6131ff9"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adb3d3bf-3c52-4b21-aac4-44d4a4bfa18a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""514f9ffc-a7a9-4279-8e9a-d9f34ba2a198"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DropWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ab8397b-ce25-4434-84f5-86bb874a13a3"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DropWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdb4f62a-daf8-40a4-9061-ff0bf24ae3a7"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PickUpWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8c32aae-7fdb-4ac7-a846-1594155d5089"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PickUpWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b05f2a46-15e1-4085-8f77-c9b37199dbdb"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c4a3c18-c012-4cb9-8f45-80ef48162071"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""837f3e4c-ae1d-4388-ab78-bb0a63b794d2"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CallingWeaponBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94080dab-a86e-4c99-bfdf-c84db4fce6e7"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CallingWeaponBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControl
        m_PlayerControl = asset.FindActionMap("PlayerControl", throwIfNotFound: true);
        m_PlayerControl_Move = m_PlayerControl.FindAction("Move", throwIfNotFound: true);
        m_PlayerControl_Jump = m_PlayerControl.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControl_RotateCam = m_PlayerControl.FindAction("RotateCam", throwIfNotFound: true);
        m_PlayerControl_PrimaryAttack = m_PlayerControl.FindAction("PrimaryAttack", throwIfNotFound: true);
        m_PlayerControl_Dodge = m_PlayerControl.FindAction("Dodge", throwIfNotFound: true);
        m_PlayerControl_DropWeapon = m_PlayerControl.FindAction("DropWeapon", throwIfNotFound: true);
        m_PlayerControl_PickUpWeapon = m_PlayerControl.FindAction("PickUpWeapon", throwIfNotFound: true);
        m_PlayerControl_Aim = m_PlayerControl.FindAction("Aim", throwIfNotFound: true);
        m_PlayerControl_CallingWeaponBack = m_PlayerControl.FindAction("CallingWeaponBack", throwIfNotFound: true);
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

    // PlayerControl
    private readonly InputActionMap m_PlayerControl;
    private IPlayerControlActions m_PlayerControlActionsCallbackInterface;
    private readonly InputAction m_PlayerControl_Move;
    private readonly InputAction m_PlayerControl_Jump;
    private readonly InputAction m_PlayerControl_RotateCam;
    private readonly InputAction m_PlayerControl_PrimaryAttack;
    private readonly InputAction m_PlayerControl_Dodge;
    private readonly InputAction m_PlayerControl_DropWeapon;
    private readonly InputAction m_PlayerControl_PickUpWeapon;
    private readonly InputAction m_PlayerControl_Aim;
    private readonly InputAction m_PlayerControl_CallingWeaponBack;
    public struct PlayerControlActions
    {
        private @InputControl m_Wrapper;
        public PlayerControlActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControl_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerControl_Jump;
        public InputAction @RotateCam => m_Wrapper.m_PlayerControl_RotateCam;
        public InputAction @PrimaryAttack => m_Wrapper.m_PlayerControl_PrimaryAttack;
        public InputAction @Dodge => m_Wrapper.m_PlayerControl_Dodge;
        public InputAction @DropWeapon => m_Wrapper.m_PlayerControl_DropWeapon;
        public InputAction @PickUpWeapon => m_Wrapper.m_PlayerControl_PickUpWeapon;
        public InputAction @Aim => m_Wrapper.m_PlayerControl_Aim;
        public InputAction @CallingWeaponBack => m_Wrapper.m_PlayerControl_CallingWeaponBack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @RotateCam.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRotateCam;
                @RotateCam.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRotateCam;
                @RotateCam.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRotateCam;
                @PrimaryAttack.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryAttack;
                @PrimaryAttack.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryAttack;
                @PrimaryAttack.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryAttack;
                @Dodge.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnDodge;
                @DropWeapon.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnDropWeapon;
                @DropWeapon.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnDropWeapon;
                @DropWeapon.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnDropWeapon;
                @PickUpWeapon.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPickUpWeapon;
                @PickUpWeapon.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPickUpWeapon;
                @PickUpWeapon.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPickUpWeapon;
                @Aim.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAim;
                @CallingWeaponBack.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnCallingWeaponBack;
                @CallingWeaponBack.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnCallingWeaponBack;
                @CallingWeaponBack.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnCallingWeaponBack;
            }
            m_Wrapper.m_PlayerControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @RotateCam.started += instance.OnRotateCam;
                @RotateCam.performed += instance.OnRotateCam;
                @RotateCam.canceled += instance.OnRotateCam;
                @PrimaryAttack.started += instance.OnPrimaryAttack;
                @PrimaryAttack.performed += instance.OnPrimaryAttack;
                @PrimaryAttack.canceled += instance.OnPrimaryAttack;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @DropWeapon.started += instance.OnDropWeapon;
                @DropWeapon.performed += instance.OnDropWeapon;
                @DropWeapon.canceled += instance.OnDropWeapon;
                @PickUpWeapon.started += instance.OnPickUpWeapon;
                @PickUpWeapon.performed += instance.OnPickUpWeapon;
                @PickUpWeapon.canceled += instance.OnPickUpWeapon;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @CallingWeaponBack.started += instance.OnCallingWeaponBack;
                @CallingWeaponBack.performed += instance.OnCallingWeaponBack;
                @CallingWeaponBack.canceled += instance.OnCallingWeaponBack;
            }
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerControlActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRotateCam(InputAction.CallbackContext context);
        void OnPrimaryAttack(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnDropWeapon(InputAction.CallbackContext context);
        void OnPickUpWeapon(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnCallingWeaponBack(InputAction.CallbackContext context);
    }
}

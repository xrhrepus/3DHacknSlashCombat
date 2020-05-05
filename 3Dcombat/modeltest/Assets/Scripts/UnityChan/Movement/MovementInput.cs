using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    private InputControl _inputActions;

    [Header("MovementBehavior")]
    [SerializeField] private MovementBehavior _movementBehavior;
    private void OnEnable()
    {
        _inputActions.Enable();
    }
    private void OnDisable()
    {
        _inputActions.Disable();
    }
    private void Awake()
    {

        _inputActions = new InputControl();
        _inputActions.PlayerControl.Move.performed += _move => { _movementBehavior.SetMoveValue(_move.ReadValue<Vector2>()); };
        _inputActions.PlayerControl.Jump.performed += _jump => { _movementBehavior.JumpPerformed(); };
        _inputActions.PlayerControl.Dodge.performed += _dodge => { _movementBehavior.DodgePerformed(); };

    }

}

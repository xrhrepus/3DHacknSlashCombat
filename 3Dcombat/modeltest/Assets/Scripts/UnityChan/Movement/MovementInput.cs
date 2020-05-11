using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    private InputControl _inputActions;

    [Header("MovementBehavior")]
    [SerializeField] private MovementBehavior _movementBehavior;
    //private void OnEnable()
    //{
    //    _inputActions.Enable();
    //}
    //private void OnDisable()
    //{
    //    _inputActions.Disable();
    //}
    public void MovePerformed(Vector2 val)
    {
        _movementBehavior.SetMoveValue(val);
    }
    public void JumpPerformed()
    {
        _movementBehavior.JumpPerformed();
    }
    public void DodgePerformed()
    {
        _movementBehavior.DodgePerformed();
    }


    private void Awake()
    {
        //move into Player.cs
        //_inputActions = new InputControl();
        //_inputActions.PlayerControl.Move.performed += _move => { MovePerformed(_move.ReadValue<Vector2>());  };
        //_inputActions.PlayerControl.Jump.performed += _jump => { JumpPerformed(); };
        //_inputActions.PlayerControl.Dodge.performed += _dodge => { DodgePerformed(); };

    }

}

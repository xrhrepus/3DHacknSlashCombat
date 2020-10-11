using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Input : MonoBehaviour
{
 
    [SerializeField]
    private PlayerInput _playerInput;
    public InputCtrl.PlayerActions KnightInputCtrl { get => _playerInput.InputCtrl.Player; }
    //
    [SerializeField][ReadOnly]
    private Vector2 _inputDirection;
    public Vector2 InputDirection { get => _inputDirection; }
    public Vector3 InputDirctionVector3 { get => new Vector3(_inputDirection.x, 0.0f, _inputDirection.y); }
    [SerializeField][ReadOnly]
    private bool _inputAttack = false;
    public bool InputAttack { get => _inputAttack; }
    //
    private Vector2 _mouseDelta;
    public Vector2 MouseDelta { get => _mouseDelta; }

    private void Awake()
    {
    }
    private void Start()
    {
        //
        KnightInputCtrl.Move.performed += _move => { ReadInputDirection(_move.ReadValue<Vector2>()); Perform_Move(); };
        //
        KnightInputCtrl.Attack.performed += _attackPerform => { _inputAttack = true; Perform_Attack(); };
        KnightInputCtrl.Attack.canceled += _attackRelease => { _inputAttack = false; Release_Attack(); };
        //
        KnightInputCtrl.View.performed += _viewChange => { _mouseDelta = _viewChange.ReadValue<Vector2>(); };

    }
    void ReadInputDirection(Vector2 dir)
    {
        _inputDirection = dir;
    }
    void Perform_Move()
    {

    }
    void Perform_Attack()
    {

    }
    void Release_Attack()
    {

    }
 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Input : MonoBehaviour
{
    //
    [SerializeField]
    private Knight _knight;
    public Knight Knight { get => _knight; }

    //
    [SerializeField]
    private PlayerInput _playerInput;
    public InputCtrl.PlayerActions KnightInputCtrl { get => _playerInput.InputCtrl.Player; }
    //
    [SerializeField][ReadOnly]
    private Vector2 _inputDirection;
    public Vector2 InputDirection { get => _inputDirection; }
    public Vector3 InputDirectionVector3 { get => new Vector3(_inputDirection.x, 0.0f, _inputDirection.y); }
    //
    [Header("Attack button Status")]
    [SerializeField][ReadOnly]
    private bool _inputAttack = false;
    public bool InputAttack { get => _inputAttack; }
    [SerializeField] private float _holdDuration = 0.4f;
    [SerializeField] [ReadOnly] private bool _atkHoldDown = false;
    [SerializeField] [ReadOnly] private float _holdDuration_timer = 0.0f;
    [SerializeField] [ReadOnly] private bool _holdTimer_Start = false;

    //
    private Vector2 _mouseDelta;
    public Vector2 MouseDelta { get => _mouseDelta; }
    
    private void Awake()
    {
    }
    private void Start()
    {
        //
        KnightInputCtrl.Move.performed += _movePerform => { ReadInputDirection(_movePerform.ReadValue<Vector2>()); Perform_Move(); };
        //KnightInputCtrl.Move.canceled += _moveRelease => { Release_Move(); };

        //
        KnightInputCtrl.Attack.performed += _attackPerform => { _inputAttack = true; Perform_Attack(); };
        KnightInputCtrl.Attack.canceled += _attackRelease => { _inputAttack = false; Release_Attack(); };
        //
        KnightInputCtrl.Jump.performed += _jumpPerform => { JumpPerform(); };
        //
        KnightInputCtrl.View.performed += _viewChange => { _mouseDelta = _viewChange.ReadValue<Vector2>(); };

    }
    //move
    void ReadInputDirection(Vector2 dir)
    {
        _inputDirection = dir;

    }
    void Perform_Move()
    {
        _knight.KnightAnimation.MovePress();
    }
    void Release_Move()
    {
        _knight.KnightAnimation.MoveRelease();
    }
    //attack
    void Perform_Attack()
    {
        _holdTimer_Start = true;
        _knight.KnightAnimation.AttackPress();
    }
    void Release_Attack()
    {
        _knight.KnightAnimation.AttackRelease();
        _holdDuration_timer = 0.0f;
        _holdTimer_Start = false;
        _atkHoldDown = false;
    }

    //jump
    void JumpPerform()
    {

    }


 //

    private void FixedUpdate()
    {
        if (_inputDirection.sqrMagnitude < 0.01f)
        {
            Release_Move();
        }
        if (_holdTimer_Start)
        {
            _holdDuration_timer += Time.fixedDeltaTime;
            if (_holdDuration_timer > _holdDuration)
            {
                _atkHoldDown = true;
                _knight.KnightAnimation.AttackHold();
            }
        }

    }

}

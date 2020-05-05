using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBehavior : MonoBehaviour
{
    [SerializeField]
    private bool isReadyToAttack = false;

    [Header("MovementBehavior")]
    [SerializeField] private MovementBehavior _movementBehavior;
    [Header("Animation")]
    [SerializeField] private Animator _animator;

    [SerializeField]
    private float spinMoveSpeed = 8.0f;

    [SerializeField]
    private float leapMoveSpeed = 7.0f;
    [SerializeField]
    private float leapForce = 7.0f;
    [SerializeField]
    private float airborneLandingForce = 7.0f;


    enum AttackState
    {
        CanCombo = 0x1 << 1,
        Finish = 0x1 << 2
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ReadyToAttack()
    {
        isReadyToAttack = true;
    }
    public void NotReadyToAttack()
    {
        isReadyToAttack = false;
    }

    #region Attack

    public void PrimaryAttackPerformed()
    {
        if (isReadyToAttack)
        {
            SetAnimator_PrimAttack();
        }
        
    }
    //public void AttackFinishing()
    //{
    //    _movementBehavior.isReadyToMove = true;
    //}
    void SetAnimator_PrimAttack()
    {
        _animator.SetTrigger("primatk");
    }
    #endregion
    #region ComboBehavior
    public void ReturnToIdlePose()
    {
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = true;
    }

    public void BasicAttack_Start()
    {
         _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
    }
    public void BasicAttack_Finish()
    {
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = true;
    }
    public void SpinAttack_Start()
    {
        if (_movementBehavior.isUserMoveInput)
        {
            //Vector2 movVal = _movementBehavior.GetMoveValue();
            _movementBehavior.SetCurrHorizonVelocityDirection(_movementBehavior.GetMoveValue());
        }
        //else
        //{
        //    _movementBehavior.SetCurrHorizonVelocityDirection(_movementBehavior.GetTransform().forward);
        //}
        _movementBehavior.RotateTowardDesireDirection();
        _movementBehavior.SetCurrHorizonSpeed(spinMoveSpeed);

    }
    public void SpinAttack_Finish()
    {
        _movementBehavior.SetHorizonSpeedZero();
    }
    public void LeapAttack_Dash()
    {
        if (_movementBehavior.isUserMoveInput)
        {
            //Vector2 movVal = _movementBehavior.GetMoveValue();
            _movementBehavior.SetCurrHorizonVelocityDirection(_movementBehavior.GetMoveValue());
        }
        //else
        //{
        //    _movementBehavior.SetCurrHorizonVelocityDirection(_movementBehavior.GetTransform().forward);
        //}
        _movementBehavior.RotateTowardDesireDirection();
        _movementBehavior.SetCurrHorizonSpeed(leapMoveSpeed);

    }
    public void LeapAttack_Leap()
    {
        _movementBehavior.JumpUp();
    }
    public void LeapAttack_Landing()
    {
        _movementBehavior.Airborne_ForceLanding(airborneLandingForce);
    }

    public void LeapAttack_Finish()
    {
        _movementBehavior.SetHorizonSpeedZero();
    }

    #endregion
}

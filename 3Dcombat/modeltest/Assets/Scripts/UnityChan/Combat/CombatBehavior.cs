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
    [Header("VisualHint")]
    [SerializeField] private ParticleSystem _particleSystem;


    [Header("2 Hand weapon combo")]
    [Tooltip("the playback speed of animator during the can combo state")]
    [SerializeField]
    private float comboIntervalSpeed = 0.3f;
    [Tooltip("the Normal playback speed of animator")]
    [SerializeField]
    private float normalPlaybackSpeed = 1.0f;

 
    [Header("Spin attack")]
    [SerializeField]
    private float spinMoveSpeed = 8.0f;

    [Header("Leap attack")]
    [SerializeField]
    private float leapMoveSpeed = 7.0f;
    [SerializeField]
    private float leapMoveSpeed_p2 = 7.0f;
    [SerializeField]
    private float leapForce = 7.0f;
    [SerializeField]
    private float airborneLandingForce = 7.0f;


    enum AttackState
    {
        CanCombo = 0x1 << 1,
        Finish = 0x1 << 2
    }

 
    public void ReadyToAttack()
    {
        isReadyToAttack = true;
    }
    public void NotReadyToAttack()
    {
        isReadyToAttack = false;
    }
    #region Animator Control
    public void SetAttackMotionState(int state)
    {
        _animator.SetInteger("attackMotion", state);
    }
    public void SetAnimatorSpeed(float speed)
    {
        _animator.speed = speed;
    }
    public void ComboVisualHintOn()
    {
        _particleSystem.Play();
    }
    public void ComboVisualHintOff()
    {
        _particleSystem.Clear();
        _particleSystem.Stop();
    }

    #endregion


    #region Attack
    void ResetAttackTriggers()
    {
        _animator.ResetTrigger("primatk");
        _animator.ResetTrigger("primatkHold");
 
    }
    public void PrimaryAttackPerformed()
    {
        if (isReadyToAttack)
        {
            SetAnimatorSpeed(normalPlaybackSpeed);
            SetAnimator_PrimAttackPressed();
        }
         
    }
    public void PrimaryAttackHeld()
    {
        if (isReadyToAttack)
        {
            SetAnimatorSpeed(normalPlaybackSpeed);
            SetAnimator_PrimAttackHeld();
        }
    }

    //public void AttackFinishing()
    //{
    //    _movementBehavior.isReadyToMove = true;
    //}
    void SetAnimator_PrimAttackPressed()
    {
        _animator.SetTrigger("primatk");
    }
    void SetAnimator_PrimAttackHeld()
    {
        _animator.SetTrigger("primatkHold");
    }

    #endregion

    #region Minor adjustment on character transform
    public void Move_Forward()
    {
        _movementBehavior.SetCurrHorizonSpeed(spinMoveSpeed);
    }
    public void Move_Stop()
    {
        _movementBehavior.SetHorizonSpeedZero();

    }

    public void Rotate_ToCam()
    {
        _movementBehavior.RotateTowardDesireDirection();
    }

    #endregion

    #region ComboBehavior
    public void ReturnToIdlePose()
    {
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = true;
    }
    #region TwoHandMelee attack
    #region TwoHandMelee_ATK_1
    //2-hand melee Atk1
    public void TwoHandMelee_ATK_1_Phase1()
    {
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        NotReadyToAttack();
    }
    public void TwoHandMelee_ATK_1_Phase2()
    {
        ReadyToAttack();
        SetAnimatorSpeed(comboIntervalSpeed);
        ComboVisualHintOn();


    }
    public void TwoHandMelee_ATK_1_Phase3()
    {
        NotReadyToAttack();
        SetAnimatorSpeed(normalPlaybackSpeed);
        ComboVisualHintOff();
    }
    public void TwoHandMelee_ATK_1_Phase4()
    {
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = true;
        ReadyToAttack();
    }

    #endregion
    #region TwoHandMelee_ATK_2
    //2-hand melee Atk1
    public void TwoHandMelee_ATK_2_Phase1()
    {
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        NotReadyToAttack();
    }
    public void TwoHandMelee_ATK_2_Phase2()
    {
        ReadyToAttack();
        SetAnimatorSpeed(comboIntervalSpeed);
        ComboVisualHintOn();
    }
    public void TwoHandMelee_ATK_2_Phase3()
    {
        NotReadyToAttack();
        SetAnimatorSpeed(normalPlaybackSpeed);
        ComboVisualHintOff();
    }
    public void TwoHandMelee_ATK_2_Phase4()
    {
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = true;
        ReadyToAttack();
    }

    #endregion
    #region TwoHandMelee_ATK_3(Spin)
    //2-hand melee Atk3
    public void TwoHandMelee_ATK_3_Phase1()
    {
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        NotReadyToAttack();
    }
    public void TwoHandMelee_ATK_3_Phase2()
    {
        SpinAttack_Dash();
    }
    public void TwoHandMelee_ATK_3_Phase3()
    {
        ReadyToAttack();
        SetAnimatorSpeed(comboIntervalSpeed);
        ComboVisualHintOn();
    }
    public void TwoHandMelee_ATK_3_Phase4()
    {
        _movementBehavior.SetHorizonSpeedZero();

    }
    public void TwoHandMelee_ATK_3_Phase5()
    {
        SetAnimatorSpeed(normalPlaybackSpeed);
        NotReadyToAttack();
        ComboVisualHintOff();

        SpinAttack_Finish();
        //ReadyToAttack();
    }

    void SpinAttack_Dash()
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


    void SpinAttack_Finish()
    {
        _movementBehavior.SetHorizonSpeedZero();
    }

    #endregion
    #region TwoHandMelee_ATK_4(Leap)
    //2-hand melee Atk3
    public void TwoHandMelee_ATK_4_Phase1()
    {
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        NotReadyToAttack();
    }
    public void TwoHandMelee_ATK_4_Phase2()
    {
        LeapAttack_Dash();
    }
    public void TwoHandMelee_ATK_4_Phase3()
    {
        LeapAttack_Leap();
    }
    public void TwoHandMelee_ATK_4_Phase4()
    {
        LeapAttack_Dash_2();

    }
    public void TwoHandMelee_ATK_4_Phase5()
    {
        LeapAttack_Landing();

    }
    public void TwoHandMelee_ATK_4_Phase6()
    {

        SetAnimatorSpeed(normalPlaybackSpeed);
        NotReadyToAttack();
        ComboVisualHintOff();

        LeapAttack_Finish();
        //ReadyToAttack();
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
        //_movementBehavior.SetCurrHorizonSpeed(leapMoveSpeed);
        _movementBehavior.SetCurrHorizonSpeed(leapMoveSpeed);


    }
    public void LeapAttack_Leap()
    {
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.JumpUp(leapForce);
    }
    public void LeapAttack_Dash_2()
    {
        _movementBehavior.SetCurrHorizonSpeed(leapMoveSpeed_p2);

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

    #endregion

 

    #endregion
}

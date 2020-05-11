using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBehavior : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private bool isReadyToAttack = false;
    public bool isAttacking { get; private set; }

    [Header("MovementBehavior")]
    [SerializeField] private MovementBehavior _movementBehavior;
    [Header("Animation")]
    [SerializeField] private Animator _animator;
    [Header("VisualHint")]
    [SerializeField] private ParticleSystem _particleSystem;

 
    [Header("Fist combat combo")]
    [Tooltip("the playback speed of animator during the can combo state")]
    [SerializeField]
    private float comboIntervalSpeed_f1 = 0.3f;
    [SerializeField]
    private float comboIntervalSpeed_f2 = 0.3f;
    [SerializeField]
    private float comboIntervalSpeed_f3 = 0.3f;
    [SerializeField]
    private float comboIntervalSpeed_f4 = 0.3f;

    //[Tooltip("the Normal playback speed of animator")]
    //[SerializeField]
    //private float normalPlaybackSpeed = 1.0f;

    [Header("Fist attack 4(spin kick)")]
    [SerializeField]
    private float jumpForce_f4 = 150f;

    [Header("Fist attack 5(charge rising punch)")]
    [SerializeField]
    private float riseForce_f5 = 150f;
    [SerializeField]
    private float riseHorizonSpd = 4.0f;
    [SerializeField]
    private float midAirPlaybackSpd_rise = 0.3f;

    //[Header("Leap attack")]
    //[SerializeField]
    //private float leapMoveSpeed = 7.0f;
    //[SerializeField]
    //private float leapMoveSpeed_p2 = 7.0f;
    //[SerializeField]
    //private float leapForce = 7.0f;
    //[SerializeField]
    //private float airborneLandingForce = 7.0f;

    #region 2-hand melee weapon

    [Header("2 Hand weapon combo")]
    [Tooltip("the playback speed of animator during the can combo state")]
    [SerializeField]
    private float comboIntervalSpeed_2hw1 = 0.3f;
    [SerializeField]
    private float comboIntervalSpeed_2hw2 = 0.3f;
    [SerializeField]
    private float comboIntervalSpeed_2hw3 = 0.3f;

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
    #endregion

    #endregion
 
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
    public void ResetAnimatorSpeed()
    {
        _animator.speed = normalPlaybackSpeed;
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
    public void SetWeaponType(int type)
    {
        _animator.SetInteger("weaponType", type);
    }
 
    #endregion

    #region Attack button status
    public void ResetAttackTriggers()
    {
        _animator.ResetTrigger("primatk");
        _animator.ResetTrigger("primatkHold");
        _animator.ResetTrigger("primatkHoldToRelease");


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
            SetAnimator_PrimAttackHold();
        }
    }
    public void PrimaryAttackHoldToRelease()
    {
        //if (isReadyToAttack)
        {
            SetAnimatorSpeed(normalPlaybackSpeed);
            SetAnimator_PrimAttackHoldToRelease();
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
    void SetAnimator_PrimAttackHold()
    {
        _animator.SetTrigger("primatkHold");
    }
    void SetAnimator_PrimAttackHoldToRelease()
    {
        _animator.SetTrigger("primatkHoldToRelease");
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
        if (_movementBehavior.isUserMoveInput)
            _movementBehavior.SetCurrHorizonVelocityDirection(_movementBehavior.GetMoveValue());
        _movementBehavior.RotateTowardDesireDirection();
        //_movementBehavior.SetCurrHorizonSpeed(1.2f);

    }

    #endregion

    #region Combat behavior
    #region SheathingWeapon/Reset character movment conditions
    public void SheathingWeapon()
    {
        _movementBehavior.isReadyToMove = false;
        _movementBehavior.ReadyToJump(false);
        NotReadyToAttack();
    }
    public void UnsheathingWeapon()
    {
        _movementBehavior.isReadyToMove = false;
        _movementBehavior.ReadyToJump(false);
        _movementBehavior.SetHorizonSpeedZero();
    }

    public void ReturnToIdlePose()
    {
        isAttacking = false;
        _movementBehavior.IdlePoseStart();
        ReadyToAttack();
        ResetAnimatorSpeed();
        ResetAttackTriggers();
    }
    public void ReturnToRunPose()
    {
        isAttacking = false;
        _movementBehavior.RunPoseStart();
        ReadyToAttack();
        ResetAnimatorSpeed();
        ResetAttackTriggers();
    }
    #endregion
    #region Fist attack
    #region Fist_Attack_1
    public void Fist_ATK_1_Phase1()
    {
        isAttacking = true;
        _movementBehavior.ReadyToJump(false);
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        Rotate_ToCam();

        NotReadyToAttack();
    }
    public void Fist_ATK_1_Phase2()
    {
        //_movementBehavior.SetHorizonSpeedZero();
        ReadyToAttack();
        SetAnimatorSpeed(comboIntervalSpeed_f1);
        ComboVisualHintOn();
    }
    public void Fist_ATK_1_Phase3()
    {
        NotReadyToAttack();
        SetAnimatorSpeed(normalPlaybackSpeed);
        ComboVisualHintOff();
    }
    public void Fist_ATK_1_Phase4()
    {
        _movementBehavior.SetHorizonSpeedZero();
        //_movementBehavior.isReadyToMove = true;
        //ReadyToAttack();
    }
    #endregion
    #region Fist_Attack_2
    public void Fist_ATK_2_Phase1()
    {
        isAttacking = true;
        _movementBehavior.ReadyToJump(false);

        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        NotReadyToAttack();
        Rotate_ToCam();

    }
    public void Fist_ATK_2_Phase2()
    {

        ReadyToAttack();
        SetAnimatorSpeed(comboIntervalSpeed_f2);
        ComboVisualHintOn();
    }
    public void Fist_ATK_2_Phase3()
    {
        NotReadyToAttack();
        SetAnimatorSpeed(normalPlaybackSpeed);
        ComboVisualHintOff();
    }
    public void Fist_ATK_2_Phase4()
    {
        _movementBehavior.SetHorizonSpeedZero();
        //_movementBehavior.isReadyToMove = true;
        //ReadyToAttack();
    }
    #endregion
    #region Fist_Attack_3
    public void Fist_ATK_3_Phase1()
    {
        isAttacking = true;
        _movementBehavior.ReadyToJump(false);

        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        NotReadyToAttack();
        Rotate_ToCam();

    }
    public void Fist_ATK_3_Phase2()
    {

        ReadyToAttack();
        SetAnimatorSpeed(comboIntervalSpeed_f3);
        ComboVisualHintOn();
    }
    public void Fist_ATK_3_Phase3()
    {
        NotReadyToAttack();
        SetAnimatorSpeed(normalPlaybackSpeed);
        ComboVisualHintOff();
    }
    public void Fist_ATK_3_Phase4()
    {
        _movementBehavior.SetHorizonSpeedZero();
       // _movementBehavior.isReadyToMove = true;
        //ReadyToAttack();
    }
    #endregion
    #region Fist_Attack_4
    public void Fist_ATK_4_Phase1()
    {
        isAttacking = true;
        _movementBehavior.ReadyToJump(false);
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        NotReadyToAttack();
        Rotate_ToCam();

    }
 
    public void Fist_ATK_4_Phase2()
    {

//        ReadyToAttack();
//        SetAnimatorSpeed(comboIntervalSpeed_f3);
//        ComboVisualHintOn();
    }
    public void Fist_ATK_4_Phase3()
    {
//        NotReadyToAttack();
//        SetAnimatorSpeed(normalPlaybackSpeed);
//        ComboVisualHintOff();
    }
    public void Fist_ATK_4_Phase4()
    {
        _movementBehavior.SetHorizonSpeedZero();
       // _movementBehavior.isReadyToMove = true;
        //ReadyToAttack();
    }
    #endregion
    #region Fist_Attack_5 rising punch
    public void Fist_ATK_5_Phase1()//charge
    {
        isAttacking = true;
        _movementBehavior.ReadyToJump(false);
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        _movementBehavior.isReadyToDodge = false;
        NotReadyToAttack();
 
    }

    public void Fist_ATK_5_Phase2()//rise
    {
        Fist_ATK_5_Rise();
    }
    public void Fist_ATK_5_Phase3()//floating
    {
        _movementBehavior.SetRigidbodyMass(0.2f);
        _movementBehavior.SetCurrHorizonSpeed(riseHorizonSpd * 0.5f);

        NotReadyToAttack();
        SetAnimatorSpeed(midAirPlaybackSpd_rise);
        //        ComboVisualHintOff();
    }
    public void Fist_ATK_5_Phase4()//falling
    {
        _movementBehavior.ResetRigidbodyMass();
        ResetAnimatorSpeed();

    }

    public void Fist_ATK_5_Phase5()//falling p2
    {
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = true;//allow air move
        //ReadyToAttack();
    }

    void Fist_ATK_5_Charge()
    {

    }
    void Fist_ATK_5_Rise()
    {
        Rotate_ToCam();
        _movementBehavior.SetCurrHorizonSpeed(riseHorizonSpd);

        //_movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.JumpUp(riseForce_f5);
    }
    #endregion

    #endregion

    #region TwoHandMelee attack
    #region TwoHandMelee_ATK_1
    //2-hand melee Atk1
    public void TwoHandMelee_ATK_1_Phase1()
    {
        isAttacking = true;
        _movementBehavior.ReadyToJump(false);
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        NotReadyToAttack();
 
    }
    public void TwoHandMelee_ATK_1_Phase2()
    {
        ReadyToAttack();
        SetAnimatorSpeed(comboIntervalSpeed_2hw1);
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
        isAttacking = true;
        Rotate_ToCam();
        _movementBehavior.ReadyToJump(false);
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        NotReadyToAttack();
    }
    public void TwoHandMelee_ATK_2_Phase2()
    {
        ReadyToAttack();
        SetAnimatorSpeed(comboIntervalSpeed_2hw2);
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
        isAttacking = true;
        _movementBehavior.ReadyToJump(false);
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
        SetAnimatorSpeed(comboIntervalSpeed_2hw3);
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
        Rotate_ToCam();
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
        isAttacking = true;
        _movementBehavior.ReadyToJump(false);
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.isReadyToMove = false;
        _movementBehavior.isReadyToDodge = false;

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
        Rotate_ToCam();
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

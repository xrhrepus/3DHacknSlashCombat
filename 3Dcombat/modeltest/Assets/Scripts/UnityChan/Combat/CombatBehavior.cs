using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// behaviors control the movemnt(transform/rigidbody force, velocity) of gameobject
/// might need to move animator controls to CombatEventsHandler later
/// 
/// </summary>
public class CombatBehavior : MonoBehaviour
{
    #region Fields
    [Header("Combat input control")]
    [SerializeField] private CombatInput _combatInput;
 
    [SerializeField]
    private bool isReadyToAttack = false;
    public bool isAttacking { get; private set; }

    [Header("MovementBehavior")]
    [SerializeField] private MovementBehavior _movementBehavior;
    [Header("Animation")]
    [SerializeField] private Animator _animator;
    [Header("VisualHint")]
    [SerializeField] private ParticleSystem _particleSystem;


    [Header("CombatHitBoxControl")]
    [SerializeField] private CombatHitBoxControl _combatHitBoxControl;

    #region Fist combat
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

    [Header("Fist attack 4(spin kick)")]
    [SerializeField]
    private float jumpForce_f4 = 250f;

    [Header("Fist attack 5(charge rising punch)")]
    [Tooltip("the time to reach fully charge")]
    [SerializeField]
    private float maxChargeTime_f5 = 1.0f;
    [Tooltip("the current charge progress")]
    [SerializeField]
    private float chargeProgress_f5 = 0.0f;
    public bool isCharging_f5 { get; private set; }
    [Tooltip("the min uprising force")]
    [SerializeField]
    private float minRiseForce_f5 = 200f;
    [SerializeField]
    [Tooltip("final upward force =  minRiseForce_f5 + extraRiseForce_f5 * (chargeProgress_f5 / maxChargeTime_f5)")]
    private float extraRiseForce_f5 = 450f;
    [SerializeField]
    private float airborneHorizonSpd = 4.0f;
    [SerializeField]
    private float airbornePlaybackSpd_rise = 0.3f;

    #endregion


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

    [Header("Aiming")]
    [SerializeField] private bool _isAiming = false;
    public bool IsAiming { get => _isAiming; }


    #endregion
    #region Awake/FixedUpdate
    private void Awake()
    {
        _combatInput = GetComponent<CombatInput>();
    }
    private void FixedUpdate()
    {
        if (isCharging_f5 && chargeProgress_f5 < maxChargeTime_f5)
        {
            chargeProgress_f5 += Time.fixedDeltaTime;
        }
    }
    private void Update()
    {
        _animator.SetBool("isAttacking", isAttacking);
    }
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
    public void SetAnimator_WeaponType(int type)
    {
        _animator.SetInteger("weaponType", type);
    }
    public void Set_IsAiming(bool holdDown)
    {
        _animator.SetBool("isAiming", holdDown);
        //_animator.SetLayerWeight(_animator.GetLayerIndex("Base Layer"), holdDown? 0.0f : 1.0f);

        _isAiming = holdDown;
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
        _movementBehavior.Rotate_To_Cam();
        //if (_movementBehavior.isUserMoveInput)
        //    _movementBehavior.SetCurrHorizonVelocityDirection(_movementBehavior.GetMoveValue());
        //_movementBehavior.RotateTowardDesireDirection();
        

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
        _combatHitBoxControl.Fist_A1();
    }
    public void Fist_ATK_1_Phase3()
    {
        NotReadyToAttack();
        SetAnimatorSpeed(normalPlaybackSpeed);
        ComboVisualHintOff();
        _combatHitBoxControl.Fist_All_Off();

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
        _combatHitBoxControl.Fist_A2();

    }
    public void Fist_ATK_2_Phase3()
    {
        NotReadyToAttack();
        SetAnimatorSpeed(normalPlaybackSpeed);
        ComboVisualHintOff();
        _combatHitBoxControl.Fist_All_Off();

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
        _combatHitBoxControl.Fist_A3();
    }
    public void Fist_ATK_3_Phase3()
    {
        NotReadyToAttack();
        SetAnimatorSpeed(normalPlaybackSpeed);
        ComboVisualHintOff();
        _combatHitBoxControl.Fist_All_Off();

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
        _combatHitBoxControl.Fist_A4();

        //        ReadyToAttack();
        //        SetAnimatorSpeed(comboIntervalSpeed_f3);
        //        ComboVisualHintOn();
    }
    public void Fist_ATK_4_Phase3()
    {
//        NotReadyToAttack();
//        SetAnimatorSpeed(normalPlaybackSpeed);
        _combatHitBoxControl.Fist_All_Off();
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
        isCharging_f5 = true;
 
    }
    private void Fist_ATK_5_ResetChargeTimer()
    {
        isCharging_f5 = false;
        chargeProgress_f5 = 0.0f;
    }
    public void Fist_ATK_5_Phase2()//rise
    {
        Fist_ATK_5_Rise();
        Fist_ATK_5_ResetChargeTimer();
        _combatHitBoxControl.Fist_A5();

    }
    public void Fist_ATK_5_Phase3()//floating
    {
        _movementBehavior.SetRigidbodyMass(0.2f);
        _movementBehavior.SetCurrHorizonSpeed(airborneHorizonSpd * 0.5f);

        NotReadyToAttack();
        SetAnimatorSpeed(airbornePlaybackSpd_rise);
        _combatHitBoxControl.Fist_All_Off();
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
        _movementBehavior.SetCurrHorizonSpeed(airborneHorizonSpd);

        //_movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.JumpUp( minRiseForce_f5 + extraRiseForce_f5 * (chargeProgress_f5 / maxChargeTime_f5));
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
        _combatHitBoxControl.TwoHandMelee_A1();

    }
    public void TwoHandMelee_ATK_1_Phase3()
    {
        NotReadyToAttack();
        SetAnimatorSpeed(normalPlaybackSpeed);
        ComboVisualHintOff();
        _combatHitBoxControl.TwoHandMelee_All_Off();
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
        _combatHitBoxControl.TwoHandMelee_A2();
    }
    public void TwoHandMelee_ATK_2_Phase3()
    {
        NotReadyToAttack();
        SetAnimatorSpeed(normalPlaybackSpeed);
        ComboVisualHintOff();
        _combatHitBoxControl.TwoHandMelee_All_Off();
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
        _combatHitBoxControl.TwoHandMelee_A3();
    }
    public void TwoHandMelee_ATK_3_Phase4()
    {
        _movementBehavior.SetHorizonSpeedZero();
        _combatHitBoxControl.TwoHandMelee_All_Off();

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
        _combatHitBoxControl.TwoHandMelee_A4();

    }
    public void TwoHandMelee_ATK_4_Phase6()
    {

        SetAnimatorSpeed(normalPlaybackSpeed);
        NotReadyToAttack();
        ComboVisualHintOff();

        LeapAttack_Finish();
        _combatHitBoxControl.TwoHandMelee_All_Off();
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
    #region TwoHandMelee_ATK_5(Throw)
    //2-hand melee Atk5

    //may have lock-on system later
    //leave P1 for lock-on 
    public void TwoHandMelee_ATK_5_Phase1()
    {
        isAttacking = true;
        Rotate_ToCam();
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.ReadyToJump(false);
        _movementBehavior.isReadyToMove = false;
        _movementBehavior.isReadyToDodge = false;

        //lock-on
    }

    //throw out
    public void TwoHandMelee_ATK_5_Phase2()
    {
        _combatInput.Player.ThrowingWeaponAttack();
        //ReadyToAttack();
        //SetAnimatorSpeed(comboIntervalSpeed_2hw2);
        //ComboVisualHintOn();

    }

    ////back to no weapon state (Fist)
    //public void TwoHandMelee_ATK_5_Phase3()
    //{
    //    NotReadyToAttack();
    //    SetAnimatorSpeed(normalPlaybackSpeed);
    //    ComboVisualHintOff();

    //}
    //public void TwoHandMelee_ATK_5_Phase4()
    //{
    //    _movementBehavior.SetHorizonSpeedZero();
    //    _movementBehavior.isReadyToMove = true;
    //    ReadyToAttack();

    //}

    #endregion
    #region TwoHandMelee_ATK_6(Aim Throw)
    //2-hand melee Atk5

    //may have lock-on system later
    //leave P1 for lock-on 
    public void TwoHandMelee_ATK_6_Phase1()
    {
        isAttacking = true;
        //Rotate_ToCam();
        ResetAttackTriggers();
        _movementBehavior.SetHorizonSpeedZero();
        _movementBehavior.ReadyToJump(false);
        _movementBehavior.isReadyToMove = false;
        _movementBehavior.isReadyToDodge = false;
        _animator.SetLayerWeight(_animator.GetLayerIndex("RightArm"), 0.0f);

        //lock-on
    }

    //throw out
    public void TwoHandMelee_ATK_6_Phase2()
    {
        _combatInput.Player.ThrowingWeaponAttack();
        Set_IsAiming(false);

        //ReadyToAttack();
        //SetAnimatorSpeed(comboIntervalSpeed_2hw2);
        //ComboVisualHintOn();

    }
    public void TwoHandMelee_ATK_6_Phase3()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("RightArm"), 1.0f);
 
    }


    #endregion

    #endregion



    #endregion
}

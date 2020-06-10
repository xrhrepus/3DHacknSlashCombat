using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [Header("CombatBehavior")]
    [SerializeField] private CombatBehavior _combatBehavior;

    [Header("Animation")]
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;

    [Header("VisualHint")]
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private AnimationInfoReader _animationInfoReader;

    public void SetAttackMotionState(int state)
    {
        _animator.SetInteger("attackMotion", state);
    }
    public void SetAnimatorSpeed(float speed)
    {
        //_animator.speed = speed;
        _combatBehavior.SetAnimatorSpeed(speed);
    }
    public void ResetAnimatorSpeed()
    {
        //_animator.speed = speed;
        _combatBehavior.ResetAnimatorSpeed();
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

    public void Hit()
    { }
    //
    #region Minor character adjustment
    public void Move_Forward()
    {
        _combatBehavior.Move_Forward();
    }

    public void Move_Stop()
    {
        _combatBehavior.Move_Stop();
    }
    public void Rotate_ToCam()
    {
        _combatBehavior.Rotate_ToCam();
    }
    public void ReturnToIdlePose()
    {
        _combatBehavior.ReturnToIdlePose();
    }
    public void ReturnToRunPose()
    {
        _combatBehavior.ReturnToRunPose();
    }

    #endregion
    #region Set animator parameters
    public void ReadyToAttack()
    {
        _combatBehavior.ReadyToAttack();
    }
    public void NotReadyToAttack()
    {
        _combatBehavior.NotReadyToAttack();
    }
    public void ResetAttackTriggers()
    {
        _combatBehavior.ResetAttackTriggers();
    }

    #endregion

    #region Receive impact
    public void Receive_Impact()
    {
        _combatBehavior.InfluencedByImpact();
    }
    #endregion
    //
    #region Fist attack
    #region Fist attack 1
    public void Fist_ATK_1_Phase1()
    {
        _combatBehavior.Fist_ATK_1_Phase1();
        //_animationInfoReader.AIReaderStart();
    }
    public void Fist_ATK_1_Phase2()
    {
        _combatBehavior.Fist_ATK_1_Phase2();
    }
    public void Fist_ATK_1_Phase3()
    {
        _combatBehavior.Fist_ATK_1_Phase3();
    }
    public void Fist_ATK_1_Phase4()
    {
        _combatBehavior.Fist_ATK_1_Phase4();
        //_animationInfoReader.AIReaderStop();
        //_animationInfoReader.AIReaderGetTime();
    }

    #endregion
    #region Fist attack 2
    public void Fist_ATK_2_Phase1()
    {
        _combatBehavior.Fist_ATK_2_Phase1();
    }
    public void Fist_ATK_2_Phase2()
    {
        _combatBehavior.Fist_ATK_2_Phase2();
    }
    public void Fist_ATK_2_Phase3()
    {
        _combatBehavior.Fist_ATK_2_Phase3();
    }
    public void Fist_ATK_2_Phase4()
    {
        _combatBehavior.Fist_ATK_2_Phase4();
    }

    #endregion
    #region Fist attack 3
    public void Fist_ATK_3_Phase1()
    {
        _combatBehavior.Fist_ATK_3_Phase1();
    }
    public void Fist_ATK_3_Phase2()
    {
        _combatBehavior.Fist_ATK_3_Phase2();
    }
    public void Fist_ATK_3_Phase3()
    {
        _combatBehavior.Fist_ATK_3_Phase3();
    }
    public void Fist_ATK_3_Phase4()
    {
        _combatBehavior.Fist_ATK_3_Phase4();
    }

    #endregion
    #region Fist attack 4
    public void Fist_ATK_4_Phase1()
    {
        _combatBehavior.Fist_ATK_4_Phase1();
    }
    public void Fist_ATK_4_Phase2()
    {
        _combatBehavior.Fist_ATK_4_Phase2();
    }
    public void Fist_ATK_4_Phase3()
    {
        _combatBehavior.Fist_ATK_4_Phase3();
    }
    public void Fist_ATK_4_Phase4()
    {
        _combatBehavior.Fist_ATK_4_Phase4();
    }

    #endregion
    #region Fist attack 5
    public void Fist_ATK_5_Phase1()
    {
        _combatBehavior.Fist_ATK_5_Phase1();
    }
    public void Fist_ATK_5_Phase2()
    {
        _combatBehavior.Fist_ATK_5_Phase2();
    }
    public void Fist_ATK_5_Phase3()
    {
        _combatBehavior.Fist_ATK_5_Phase3();
    }
    public void Fist_ATK_5_Phase4()
    {
        _combatBehavior.Fist_ATK_5_Phase4();
    }
    public void Fist_ATK_5_Phase5()
    {
        _combatBehavior.Fist_ATK_5_Phase5();
    }

    #endregion


    #endregion

    #region TwoHandMelee attack
    //Unsheath weapon
    #region Unsheath weapon
    public void UnsheathWeapon()
    {
        _player.UnsheathWeapon();
    }
    public void SheathWeapon()
    {
        _player.SheathWeapon();
    }
    public void SheathingWeapon()
    {
        _combatBehavior.SheathingWeapon();
    }
    public void UnsheathingWeapon()
    {
        _combatBehavior.UnsheathingWeapon();
    }

    #endregion



    //2-hand melee Atk1
    //=============
    public void TwoHandMelee_ATK_1_Phase1()
    {
        _combatBehavior.TwoHandMelee_ATK_1_Phase1();
    }
    public void TwoHandMelee_ATK_1_Phase2()
    {
        _combatBehavior.TwoHandMelee_ATK_1_Phase2();
    }
    public void TwoHandMelee_ATK_1_Phase3()
    {
        _combatBehavior.TwoHandMelee_ATK_1_Phase3();
    }
    public void TwoHandMelee_ATK_1_Phase4()
    {
        _combatBehavior.TwoHandMelee_ATK_1_Phase4();
    }
    //2-hand melee Atk2
    //=============
    public void TwoHandMelee_ATK_2_Phase1()
    {
        _combatBehavior.TwoHandMelee_ATK_2_Phase1();
    }
    public void TwoHandMelee_ATK_2_Phase2()
    {
        _combatBehavior.TwoHandMelee_ATK_2_Phase2();
    }
    public void TwoHandMelee_ATK_2_Phase3()
    {
        _combatBehavior.TwoHandMelee_ATK_2_Phase3();
    }
    public void TwoHandMelee_ATK_2_Phase4()
    {
        _combatBehavior.TwoHandMelee_ATK_2_Phase4();
    }
    //2-hand melee Atk3
    //=============
    public void TwoHandMelee_ATK_3_Phase1()
    {
        _combatBehavior.TwoHandMelee_ATK_3_Phase1();
    }
    public void TwoHandMelee_ATK_3_Phase2()
    {
        _combatBehavior.TwoHandMelee_ATK_3_Phase2();
    }
    public void TwoHandMelee_ATK_3_Phase3()
    {
        _combatBehavior.TwoHandMelee_ATK_3_Phase3();
    }
    public void TwoHandMelee_ATK_3_Phase4()
    {
        _combatBehavior.TwoHandMelee_ATK_3_Phase4();
    }
    public void TwoHandMelee_ATK_3_Phase5()
    {
        _combatBehavior.TwoHandMelee_ATK_3_Phase5();
    }

    //2-hand melee Atk4
    //=============
    public void TwoHandMelee_ATK_4_Phase1()
    {
        _combatBehavior.TwoHandMelee_ATK_4_Phase1();
    }
    public void TwoHandMelee_ATK_4_Phase2()
    {
        _combatBehavior.TwoHandMelee_ATK_4_Phase2();
    }
    public void TwoHandMelee_ATK_4_Phase3()
    {
        _combatBehavior.TwoHandMelee_ATK_4_Phase3();
    }
    public void TwoHandMelee_ATK_4_Phase4()
    {
        _combatBehavior.TwoHandMelee_ATK_4_Phase4();
    }
    public void TwoHandMelee_ATK_4_Phase5()
    {
        _combatBehavior.TwoHandMelee_ATK_4_Phase5();
    }
    public void TwoHandMelee_ATK_4_Phase6()
    {
        _combatBehavior.TwoHandMelee_ATK_4_Phase6();
    }

    //2-hand melee Atk5
    //=============
    public void TwoHandMelee_ATK_5_Phase1()
    {
        _combatBehavior.TwoHandMelee_ATK_5_Phase1();
    }
    public void TwoHandMelee_ATK_5_Phase2()
    {
        _combatBehavior.TwoHandMelee_ATK_5_Phase2();
    }
    //2-hand melee Atk6
    //=============
    public void TwoHandMelee_ATK_6_Phase1()
    {
        _combatBehavior.TwoHandMelee_ATK_6_Phase1();
    }
    public void TwoHandMelee_ATK_6_Phase2()
    {
        _combatBehavior.TwoHandMelee_ATK_6_Phase2();
    }
    public void TwoHandMelee_ATK_6_Phase3()
    {
        _combatBehavior.TwoHandMelee_ATK_6_Phase3();
    }
    //2-hand melee Atk7
    //throw in air
    //=============
    public void TwoHandMelee_ATK_7_Phase1()
    {
        _combatBehavior.TwoHandMelee_ATK_7_Phase1();
    }
    public void TwoHandMelee_ATK_7_Phase2()
    {
        _combatBehavior.TwoHandMelee_ATK_7_Phase2();
    }
    public void TwoHandMelee_ATK_7_Phase3()
    {
        _combatBehavior.TwoHandMelee_ATK_7_Phase3();
    }

    #endregion



}

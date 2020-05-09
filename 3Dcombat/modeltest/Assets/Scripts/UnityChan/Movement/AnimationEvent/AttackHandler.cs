using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [Header("CombatBehavior")]
    [SerializeField] private CombatBehavior _combatBehavior;

    [Header("Animation")]
    [SerializeField] private Animator _animator;

    [Header("VisualHint")]
    [SerializeField] private ParticleSystem _particleSystem;

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

    public void Hit()
    { }
    //
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
        ReadyToAttack();
    }

    //

    public void ReadyToAttack()
    {
        _combatBehavior.ReadyToAttack();
    }
    public void NotReadyToAttack()
    {
        _combatBehavior.NotReadyToAttack();
    }
    #region TwoHandMelee attack
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
    #endregion

    //===


    //public void LeapAttack_Dash()
    //{
    //    _combatBehavior.LeapAttack_Dash();
    //    NotReadyToAttack();
    //}
    //public void LeapAttack_Leap()
    //{
    //    _combatBehavior.LeapAttack_Leap();
    //}
    //public void LeapAttack_Dash_2()
    //{
    //    _combatBehavior.LeapAttack_Dash_2();
    //}

    //public void LeapAttack_Landing()
    //{
    //    _combatBehavior.LeapAttack_Landing();
    //}
    //public void LeapAttack_Finish()
    //{
    //    _combatBehavior.LeapAttack_Finish();

    //}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [Header("CombatBehavior")]
    [SerializeField] private CombatBehavior _combatBehavior;

    [Header("Animation")]
    [SerializeField] private Animator _animator;

    public void SetAttackMotionState(int state)
    {
        _animator.SetInteger("attackMotion", state);
    }
    public void Hit()
    { }
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
    //
    public void BasicAttack_Start()
    {
        _combatBehavior.BasicAttack_Start();
        NotReadyToAttack();
    }
    public void BasicAttack_Finish()
    {
        _combatBehavior.BasicAttack_Finish();
        ReadyToAttack();
    }


    public void SpinAttack_Start()
    {
        _combatBehavior.SpinAttack_Start();
        NotReadyToAttack();

    }
    public void SpinAttack_Finish()
    {
        _combatBehavior.SpinAttack_Finish();
    }

    public void LeapAttack_Dash()
    {
        _combatBehavior.LeapAttack_Dash();
        NotReadyToAttack();
    }
    public void LeapAttack_Leap()
    {
        _combatBehavior.LeapAttack_Leap();
    }
    public void LeapAttack_Landing()
    {
        _combatBehavior.LeapAttack_Landing();
    }
    public void LeapAttack_Finish()
    {
        _combatBehavior.LeapAttack_Finish();

    }

}

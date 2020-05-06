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

    //=============
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


    public void SpinAttack_Dash()
    {
        _combatBehavior.SpinAttack_Dash();
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
    public void LeapAttack_Dash_2()
    {
        _combatBehavior.LeapAttack_Dash_2();
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

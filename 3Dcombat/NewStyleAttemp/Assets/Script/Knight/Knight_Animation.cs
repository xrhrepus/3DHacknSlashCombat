using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Animation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    public Animator Animator { get => _animator; }

    //public void MoveForwardPress()
    //{ }
    //public void MoveBackwardPress()
    //{ }
    //public void MoveLeftPress()
    //{ }
    //public void MoveRightPress()
    //{ }
    public void MovePress()
    {
        _animator.SetBool("move", true);
    }
    public void MoveRelease()
    {
        _animator.SetBool("move", false);
    }

    public void AttackPress()
    {
        _animator.SetBool("attackPress", true);
    }

    public void AttackHold()
    {
        _animator.SetBool("attackHold", true);
    }

    public void AttackRelease()
    {
        _animator.SetBool("attackPress", false);
        _animator.SetBool("attackHold", false);
        _animator.SetBool("attackHoldToRelease", false);
    }

}

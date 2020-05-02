using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBehavior : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator _animator;


    // Update is called once per frame
    void Update()
    {
        
    }
    #region Attack

    public void PrimaryAttackPerformed()
    {
        SetAnimator_PrimAttack();
    }
    void SetAnimator_PrimAttack()
    {
        _animator.SetTrigger("primatk");
    }

    #endregion

}

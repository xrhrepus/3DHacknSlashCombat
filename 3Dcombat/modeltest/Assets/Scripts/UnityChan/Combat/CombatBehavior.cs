using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBehavior : MonoBehaviour
{
    [Header("MovementBehavior")]
    [SerializeField] private MovementBehavior _movementBehavior;
    [Header("Animation")]
    [SerializeField] private Animator _animator;

    enum AttackState
    {
        CanCombo = 0x1 << 1,
        Finish = 0x1 << 2
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Attack

    public void PrimaryAttackPerformed()
    {
        _movementBehavior.StopMoving();
        _movementBehavior.isReadyToMove = false;
        SetAnimator_PrimAttack();
    }
    public void AttackFinishing()
    {
        _movementBehavior.isReadyToMove = true;
    }
    void SetAnimator_PrimAttack()
    {
        _animator.SetTrigger("primatk");
    }
    #endregion

}

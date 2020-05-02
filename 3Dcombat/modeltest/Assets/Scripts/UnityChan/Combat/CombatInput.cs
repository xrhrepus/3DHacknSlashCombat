using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInput : MonoBehaviour
{

    private InputControl _inputActions;

    [Header("Animation")]
    //[SerializeField] private Animator _animator;
    [SerializeField] private UnityChanAnimationControl _UCAnimControl;

    private void OnEnable()
    {
        _inputActions.Enable();
    }
    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Awake()
    {
        Debug.Log("aw");

        _inputActions = new InputControl();
        _inputActions.PlayerControl.PrimaryAttack.performed += _primAtk => { Debug.Log("t"); PrimaryAttackPerformed(); };

    }
 
    void Update()
    {
        
    }
    #region Attack

    void PrimaryAttackPerformed()
    {
        SetAnimator_PrimAttack();
    }
    void SetAnimator_PrimAttack()
    {
        Debug.Log("pa");
        _UCAnimControl.SetParamTrigger("primatk");
    }

    #endregion
}

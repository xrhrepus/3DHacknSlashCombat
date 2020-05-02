using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInput : MonoBehaviour
{

    private InputControl _inputActions;

    [Header("CombatBehavior")]
    [SerializeField] private CombatBehavior _combatBehavior;
    //[Header("Animation")]
    //[SerializeField] private UnityChanAnimationControl _UCAnimControl;

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
 
        _inputActions = new InputControl();
        _inputActions.PlayerControl.PrimaryAttack.performed += _primAtk => { _combatBehavior.PrimaryAttackPerformed(); };

    }
 
}

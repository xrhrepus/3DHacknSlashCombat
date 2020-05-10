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
    [Header("Attack Hold down")]
    [SerializeField] private float _holdDuration = 0.4f;
    [SerializeField] private bool _atkHoldDown = false;
    [SerializeField] private float _holdDuration_timer = 0.0f;
    [SerializeField] private bool _holdTimer_Start = false;

 
    private void OnEnable()
    {
        _inputActions.Enable();
    }
    private void OnDisable()
    {
        _inputActions.Disable();
    }
    private void AttackPressed()
    {
        _holdTimer_Start = true;
    }
    private void AttackReleased()
    {
        if (_atkHoldDown)
        {
             _combatBehavior.PrimaryAttackHoldToRelease();
        }
        _holdDuration_timer = 0.0f;
        _holdTimer_Start = false;
        _atkHoldDown = false;
 
    }
    public bool IsAttackHold()
    {
        return _atkHoldDown;
    }
 
    private void FixedUpdate()
    {
        if (_holdTimer_Start)
        {
            _holdDuration_timer += Time.deltaTime;
        }
        if (_holdDuration_timer > _holdDuration)
        {
            _atkHoldDown = true;
            _combatBehavior.PrimaryAttackHeld();
        }
    }
    private void Awake()
    {
 
        _inputActions = new InputControl();
        _inputActions.PlayerControl.PrimaryAttack.started += _primAtk => { AttackPressed(); };
        _inputActions.PlayerControl.PrimaryAttack.performed += _primAtk => { _combatBehavior.PrimaryAttackPerformed(); };
        _inputActions.PlayerControl.PrimaryAttack.canceled += _primAtk => { AttackReleased(); };


    }

}

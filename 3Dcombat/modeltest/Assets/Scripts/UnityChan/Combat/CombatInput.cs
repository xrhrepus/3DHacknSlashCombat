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
    [SerializeField] private bool _isAtkHoldDown = false;
    [SerializeField] private float _holdDuration_timer = 0.0f;
    [SerializeField] private bool _holdDuration_StartCount = false;

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
        _holdDuration_StartCount = true;
    }
    private void AttackReleased()
    {
        _holdDuration_timer = 0.0f;
        _holdDuration_StartCount = false;
        _isAtkHoldDown = false;

    }
    public bool IsAttackHold()
    {
        return _isAtkHoldDown;
    }
    private void FixedUpdate()
    {
        if (_holdDuration_StartCount)
        {
            _holdDuration_timer += Time.deltaTime;
        }
        if (_holdDuration_timer > _holdDuration)
        {
            _isAtkHoldDown = true;
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

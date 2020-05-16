using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// combat input belongs to Player.cs, make use of CombatBehavior.cs
/// </summary>
public class CombatInput : MonoBehaviour
{
    //ref to Player
    private Player _player;

    //make use of CombatBehavior
    [Header("CombatBehavior")]
    [SerializeField] private CombatBehavior _combatBehavior;
    public CombatBehavior CombatBehavior { get => _combatBehavior; }

    //status of Attack button
    [Header("Attack button Status")]
    [SerializeField] private float _holdDuration = 0.4f;
    [SerializeField] private bool _atkHoldDown = false;
    [SerializeField] private float _holdDuration_timer = 0.0f;
    [SerializeField] private bool _holdTimer_Start = false;

    //Attack button Status
    #region Attack button Status
    public void AttackPressed()
    {
        _holdTimer_Start = true;
    }
    public void AttackPerformed()
    {
        _combatBehavior.PrimaryAttackPerformed();
    }
    public void AttackReleased()
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

    #endregion

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
        _player = GetComponent<Player>();

    }

}

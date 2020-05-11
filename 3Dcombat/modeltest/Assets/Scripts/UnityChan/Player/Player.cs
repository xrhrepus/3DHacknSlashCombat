using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool InFight { get; set; }
    //
    [SerializeField] private InputControl _inputActions;
    [SerializeField] private MovementInput _movementInput;
    [SerializeField] private CombatInput _combatInput;
    //
    [Header("MovementBehavior")]
    [SerializeField] private MovementBehavior _movementBehavior;
    [Header("CombatBehavior")]
    [SerializeField] private CombatBehavior _combatBehavior;

    [SerializeField] private Weapon _weapon;
    [SerializeField] private Player_WeaponPlacing _player_WeaponPlacing;
    //
    #region OnEnable/OnDisable
    private void OnEnable()
    {
        _inputActions.Enable();
    }
    private void OnDisable()
    {
        _inputActions.Disable();
    }

    #endregion
    public void EquipWeapon(Weapon wp)
    {
        _weapon = wp;
        _player_WeaponPlacing.ReplaceWeapon(_weapon);
        _combatBehavior.SetWeaponType( (int)wp._weaponType);
    }
    public void UnsheathWeapon()
    {
        _player_WeaponPlacing.ToHoldingLocation();
    }
    public void SheathWeapon()
    {
        _player_WeaponPlacing.ToSheathLocation();
    }

    private void Awake()
    {
        _inputActions = new InputControl();
        _inputActions.PlayerControl.Move.performed += _move => { _movementInput.MovePerformed(_move.ReadValue<Vector2>()); };
        _inputActions.PlayerControl.Jump.performed += _jump => { _movementInput.JumpPerformed(); };
        _inputActions.PlayerControl.Dodge.performed += _dodge => { _movementInput.DodgePerformed(); };

        _inputActions.PlayerControl.PrimaryAttack.started += _primAtk => { _combatInput.AttackPressed(); };
        _inputActions.PlayerControl.PrimaryAttack.performed += _primAtk => { _combatInput.AttackPerformed(); };
        _inputActions.PlayerControl.PrimaryAttack.canceled += _primAtk => { _combatInput.AttackReleased(); };

    }
    void Update()
    {
        
    }
}

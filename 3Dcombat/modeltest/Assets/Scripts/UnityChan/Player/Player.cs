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

    [Header("Weapon")]
    [SerializeField] private Weapon _weapon;
    public bool _hasWeapon { get; private set; }
    [SerializeField] private Player_WeaponPlacing _player_WeaponPlacing;
    [SerializeField] private List< Weapon> _weaponNearby = new List<Weapon>();

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
    public void AddToNearbyWeapon(Weapon wp)
    {
        _weaponNearby.Add(wp);
    }
    public void RemoveFromNearbyWeapon(Weapon wp)
    {
        _weaponNearby.Remove(wp);
    }

    public void EquipWeapon()
    {
        if (!_combatBehavior.isAttacking && _weaponNearby.Count > 0)
        {
            Weapon wp = _weaponNearby[0];
            _weapon = wp;
            _player_WeaponPlacing.ReplaceWeapon(_weapon);
            _combatBehavior.SetWeaponType((int)wp._weaponType);
            RemoveFromNearbyWeapon(wp);
            _hasWeapon = true;
        }
    }
    public void DropWeapon()// can only have one weapon
    {
        if (!_combatBehavior.isAttacking)
        {
            _weapon.gameObject.transform.parent = null;
            _weapon = null;
            _player_WeaponPlacing.SetWeaponNull();
            _combatBehavior.SetWeaponType((int)Weapon.WeaponType.fist);
            _hasWeapon = false;
        }

    }
    public void UnsheathWeapon()
    {
        if (_hasWeapon)
        {
            _player_WeaponPlacing.ToHoldingLocation();
        }
    }
    public void SheathWeapon()
    {
        if (_hasWeapon)
            _player_WeaponPlacing.ToSheathLocation();
    }

    private void Awake()
    {
        _inputActions = new InputControl();
        //move
        _inputActions.PlayerControl.Move.performed += _move => { _movementInput.MovePerformed(_move.ReadValue<Vector2>()); };
        _inputActions.PlayerControl.Jump.performed += _jump => { _movementInput.JumpPerformed(); };
        _inputActions.PlayerControl.Dodge.performed += _dodge => { _movementInput.DodgePerformed(); };
        //combat
        _inputActions.PlayerControl.PrimaryAttack.started += _primAtk => { _combatInput.AttackPressed(); };
        _inputActions.PlayerControl.PrimaryAttack.performed += _primAtk => { _combatInput.AttackPerformed(); };
        _inputActions.PlayerControl.PrimaryAttack.canceled += _primAtk => { _combatInput.AttackReleased(); };
        //pick drop weapon
        _inputActions.PlayerControl.PickUpWeapon.performed += _dropWeapon => { EquipWeapon(); };
        _inputActions.PlayerControl.DropWeapon.performed += _dropWeapon => { DropWeapon(); };

    }
    void Update()
    {
        
    }
}

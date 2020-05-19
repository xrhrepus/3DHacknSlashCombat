using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool InFight { get; set; }
    //
    private InputControl _inputActions;
    [SerializeField] private MovementInput _movementInput;
    [SerializeField] private CombatInput _combatInput;
    //
 
    [Header("Weapon")]
    [SerializeField] private Weapon _weapon;
    public bool _hasWeapon { get; private set; }
    [SerializeField] private Player_WeaponPlacing _player_WeaponPlacing;
    [SerializeField] private List< Weapon> _weaponNearby = new List<Weapon>();

    //
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
        if (!_combatInput.CombatBehavior.isAttacking && _weaponNearby.Count > 0)
        {
            Weapon wp = _weaponNearby[0];
            _weapon = wp;
            _player_WeaponPlacing.ReplaceWeapon(_weapon);
            _combatInput.CombatBehavior.SetAnimator_WeaponType((int)wp.Type);
            RemoveFromNearbyWeapon(wp);
            _weapon.StopMoving();
            _hasWeapon = true;
        }
    }
    public void DropWeapon()// can only have one weapon
    {
        if (!_combatInput.CombatBehavior.isAttacking)
        {
            DetachWeapon();
            //_weapon.gameObject.transform.parent = null;
            //_weapon = null;
            //_player_WeaponPlacing.SetWeaponNull();
            //_combatInput.CombatBehavior.SetWeaponType((int)Weapon.WeaponType.fist);
            //_hasWeapon = false;
        }

    }
    public void ThrowingWeaponAttack()
    {
        Weapon tweapon = _weapon;
        DetachWeapon();
        tweapon.ThrowingAttack(transform.position + transform.forward * 20.0f);
    }
    void DetachWeapon()// throw weapon out for some reason
    {
        if (_hasWeapon)
        {
            //_weapon.TurnOnPhysics();
            _weapon.gameObject.transform.parent = null;
            _weapon = null;
            _player_WeaponPlacing.SetWeaponNull();
            _combatInput.CombatBehavior.SetAnimator_WeaponType((int)Weapon.WeaponType.fist);
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

    public void Aiming_Start()
    {
        _combatInput.CombatBehavior.SetAnimator_IsAiming(true);
 
    }

    public void  Aiming_End()
    {
        _combatInput.CombatBehavior.SetAnimator_IsAiming(false);
    }
 

    #region OnEnable/OnDisable/Awake
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
        //move
        _inputActions.PlayerControl.Move.performed += _move => { _movementInput.MovePerformed(_move.ReadValue<Vector2>()); };
        _inputActions.PlayerControl.Jump.performed += _jump => { _movementInput.JumpPerformed(); };
        _inputActions.PlayerControl.Dodge.performed += _dodge => { _movementInput.DodgePerformed(); };
        //combat
        _inputActions.PlayerControl.PrimaryAttack.started += _primAtk => { _combatInput.AttackPressed(); };
        _inputActions.PlayerControl.PrimaryAttack.performed += _primAtk => { _combatInput.AttackPerformed(); };
        _inputActions.PlayerControl.PrimaryAttack.canceled += _primAtk => { _combatInput.AttackReleased(); };
        //pick drop weapon
        _inputActions.PlayerControl.PickUpWeapon.performed += _equipWeapon => { EquipWeapon(); };
        _inputActions.PlayerControl.DropWeapon.performed += _dropWeapon => { DropWeapon(); };
        //aim
        _inputActions.PlayerControl.Aim.performed += _aim => Aiming_Start();
        //_inputActions.PlayerControl.Aim.started += _aim => _combatInput.CombatBehavior.SetLeftTrigger(true);
        _inputActions.PlayerControl.Aim.canceled += _aim => Aiming_End();



    }

    #endregion

    void Update()
    {
        
    }
}

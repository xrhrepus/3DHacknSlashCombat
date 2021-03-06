﻿using System.Collections;
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
    [Header("Camera")]
    [SerializeField] private CameraFocus _cameraFocus;
    public CameraFocus CameraFocus { get => _cameraFocus; }

    [Header("Weapon")]
    [SerializeField] private Weapon _weapon;
    public Weapon Weapon { get=> _weapon; }
    [SerializeField] private Weapon _weaponCallingBack;

    public bool _hasWeapon { get; private set; }
    [SerializeField] private Player_WeaponPlacing _player_WeaponPlacing;
    [SerializeField] private List< Weapon> _weaponNearby = new List<Weapon>();

    [Header("LockOn")]
    [SerializeField] private LockOnDevice _lockOnDevice;
    [SerializeField] private bool _isLocking = false;

    //
    [Header("Animator")]
    [SerializeField] private Animator _animator;
    //
    [Header("Attributes")]
    [SerializeField] private Character_Attributes _attributes;
    [SerializeField] private bool _isAlive = true;
    public bool IsAlive { get => _isAlive; }

    [Header("Attack SFX")]
    [SerializeField] private SFXGroup _ATK_SFX_Voice;
    [Header("Receive Damage VFX")]
    [SerializeField] private Combat_VFXControl _getHit_VFX;

    public void SFX_Play_Damaged()
    {
        {
            string dmgVoice = "dmg" + (int)Random.Range(1, 3);
            _ATK_SFX_Voice.PlaySFX(dmgVoice);
        }
    }
    public void ReceiveDamage(float val)
    {
        //_animator.Play("Damage", 0);
        _getHit_VFX.PlayEffects();
        SFX_Play_Damaged();
        _combatInput.CombatBehavior.ReceiveImpact();
        _attributes.CurrentHp -= val;
        if (_attributes.CurrentHp <= 0.0f )
        {
            _isAlive = false;
            _movementInput.MovementBehavior.SetHorizonSpeedZero();
            _animator.SetBool("die", !_isAlive);
            _animator.speed = 1.0f;
            _animator.Play("Die", 0);
            this.enabled = false;
            //_movementInput.MovementBehavior.isReadyToMove = false;
            //_movementInput.MovementBehavior.isReadyToDodge = false;
            //_movementInput.MovementBehavior.ReadyToJump(false);
            //_combatInput.CombatBehavior.NotReadyToAttack();

        }
    }


    //
    public void AddToNearbyWeapon(Weapon wp)
    {
        _weaponNearby.Add(wp);
    }
    public void RemoveFromNearbyWeapon(Weapon wp)
    {
        _weaponNearby.Remove(wp);
    }
    public void CatchReturnWeapon_Effect()
    {
        _combatInput.CombatBehavior.TwoHandMelee_Weapon_Return();
    }

    public void EquipWeapon()
    {
        if (/*!_combatInput.CombatBehavior.isAttacking &&*/ _weaponNearby.Count > 0)
        {
            Weapon wp = _weaponNearby[0];
            _weapon = wp;
            _player_WeaponPlacing.ReplaceWeapon(_weapon);
            _combatInput.CombatBehavior.SetAnimator_WeaponType((int)wp.Type);
            RemoveFromNearbyWeapon(wp);
            _weapon.StopMoving();
            _hasWeapon = true;
            _weaponCallingBack = _weapon;
            _ATK_SFX_Voice.PlaySFX("weaponReturn");
        }
    }
    public void DropWeapon()// can only have one weapon
    {
        if (!_combatInput.CombatBehavior.isAttacking && !_combatInput.CombatBehavior.IsAiming)
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
        if (_combatInput.CombatBehavior.IsAiming)
        {
            var lcobj =_lockOnDevice.FindLockObject();
            if (lcobj != null)
            {
                if (!_movementInput.MovementBehavior.isGrounded)
                {
 
                    tweapon.ThrowingAttack_StraightTracking(lcobj.transform,5.0f);
                }
                else
                {
                    tweapon.ThrowingAttack_Tracking(lcobj.transform);
                }
            }
            else
                tweapon.ThrowingAttack(transform.position + transform.forward * 20.0f);

            //{
            //    tweapon.ThrowingAttack(lcobj.transform.position);
            //}
            //else
            //{
            //    tweapon.ThrowingAttack_Tracking(lcobj.transform);
            //}

        }
        else
        {
              tweapon.ThrowingAttack(transform.position + transform.forward * 20.0f);
        }

    }
    public void CallingWeaponBack()
    {
        if (_weaponCallingBack != null)
        {
            _weaponCallingBack.BackingToHand(transform);
        }
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
        if (!_movementInput.MovementBehavior.isDodging && _hasWeapon)
        {
            _combatInput.CombatBehavior.Set_IsAiming(true);
            _movementInput.MovementBehavior.isReadyToDodge = false;
        }
 
    }

    public void  Aiming_End()
    {
        _combatInput.CombatBehavior.Set_IsAiming(false);
        _lockOnDevice.StopLockOn();
        _movementInput.MovementBehavior.isReadyToDodge = true;

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

        //call weapon back
        _inputActions.PlayerControl.CallingWeaponBack.performed += _equipWeapon => { CallingWeaponBack(); };



    }

    #endregion

    void Update()
    {
        if (_combatInput.CombatBehavior.IsAiming)
        {
            _lockOnDevice.FindLockObject()?.LockedOn();
        }
 
    }
}

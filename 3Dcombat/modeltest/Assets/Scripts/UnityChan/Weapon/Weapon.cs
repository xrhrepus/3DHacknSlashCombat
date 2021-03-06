﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        none = -1,
        fist = 0,
        sword = 1,
        bow = 2
    }
    [SerializeField] private Weapon_PickUp _weapon_PickUp;
    [SerializeField] private Weapon_ThrowingOut _weapon_ThrowingOut;
    public Weapon_ThrowingOut Weapon_ThrowingOut { get=> _weapon_ThrowingOut; }
    [SerializeField] private BoxCollider _collisionBoxCollider;
    [SerializeField] private WeaponType _type = WeaponType.none;
    public WeaponType Type { get => _type; }

    [SerializeField] private SFXGroup _SFX_Weapon;
    public SFXGroup SFX_Weapon { get=> _SFX_Weapon; }

    [SerializeField]
    private TrailRenderer _weaponTrail;
    public TrailRenderer TrailRenderer { get => _weaponTrail; }
    private void Awake()
    {
        _weapon_PickUp.SetBelongingWeapon(this);
        //TurnOnPhysics();
    }
    public void ThrowingAttack(Vector3 dest)
    {
        _weapon_ThrowingOut.ThrowingAttack(dest);
    }
    public void ThrowingAttack_Tracking(Transform targetTF)
    {
        _weapon_ThrowingOut.ThrowingAttack_Tracking(targetTF);
    }
    public void ThrowingAttack_StraightTracking(Transform targetTF,float speedMtpl)
    {
        _weapon_ThrowingOut.ThrowingAttack_StraightTracking(targetTF, speedMtpl);
    }

    public void BackingToHand(Transform owner)
    {
        _weapon_ThrowingOut.BackToHand(owner);
    }

    public void StopMoving()
    {
        _weapon_ThrowingOut.StopMoving();
    }
    //public void TurnOnPhysics()
    //{
    //    _collisionBoxCollider.enabled = true;
    //    _weapon_ThrowingOut.Rigidbody.mass = 1.0f;
    //    _weapon_ThrowingOut.Rigidbody.isKinematic = true;
    //    _weapon_ThrowingOut.Rigidbody.WakeUp();

    //}
}

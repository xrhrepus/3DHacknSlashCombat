using System.Collections;
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
    public WeaponType _weaponType = WeaponType.none;

    private void Awake()
    {
        _weapon_PickUp.SetBelongingWeapon(this);
    }

}

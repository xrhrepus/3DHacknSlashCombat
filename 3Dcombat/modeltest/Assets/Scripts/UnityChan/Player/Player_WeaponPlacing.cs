using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WeaponPlacing : MonoBehaviour
{

    //[SerializeField] private Transform _leftHandTransform;
    //[SerializeField] private Transform _rightHandTransform;
    [SerializeField] private Transform _holdingTransform;
    [SerializeField] private Vector3 _hold_ExtraRotation;

    [SerializeField] private Transform _sheathTransform;
    [SerializeField] private Vector3 _sheath_ExtraRotation;


    [SerializeField] private GameObject _weaponGO;


    public bool isSheath { get; set; }

    private void Awake()
    {
        //Sheath();
        if (_weaponGO != null)
        {
            ToSheathLocation();
        }
        //_twoHandedWeapon.transform.SetParent(_holdingTransform);
        //_twoHandedWeapon.transform.localPosition = Vector3.zero;
        //_twoHandedWeapon.transform.localRotation = Quaternion.Euler(_extraRotation);
    }
    public void ReplaceWeapon(Weapon wp)
    {
        _weaponGO = wp.gameObject;
        ToSheathLocation();

        //TODO: might need different extra transform for diff weapons and diff characters
    }
    public void SetWeaponNull()
    {
        _weaponGO = null;
     }


    public void ToSheathLocation()
    {
//        _twoHandedWeapon.transform.position = _sheathTransform.position;
        _weaponGO.transform.SetParent(_sheathTransform);
        _weaponGO.transform.localPosition = Vector3.zero;
        _weaponGO.transform.localRotation = Quaternion.Euler(_sheath_ExtraRotation);
        isSheath = false;
    }
    public void ToHoldingLocation()
    {
        _weaponGO.transform.SetParent(_holdingTransform);
        _weaponGO.transform.localPosition = Vector3.zero;
        _weaponGO.transform.localRotation = Quaternion.Euler(_hold_ExtraRotation);
        isSheath = true;
    }
    void Update()
    {
        
    }
}

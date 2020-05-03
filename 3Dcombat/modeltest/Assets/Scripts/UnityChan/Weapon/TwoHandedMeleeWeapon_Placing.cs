using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandedMeleeWeapon_Placing : MonoBehaviour
{

    //[SerializeField] private Transform _leftHandTransform;
    //[SerializeField] private Transform _rightHandTransform;
    [SerializeField] private Transform _holdingTransform;

    [SerializeField] private Transform _sheathTransform;

    [SerializeField] private GameObject _twoHandedWeapon;

    public bool isSheath { get; set; }

    private void Awake()
    {
        //Sheath();
        _twoHandedWeapon.transform.SetParent(_holdingTransform);
        _twoHandedWeapon.transform.localPosition = Vector3.zero;
        _twoHandedWeapon.transform.localRotation = Quaternion.identity;
    }

    public void Unsheath()
    {
        _twoHandedWeapon.transform.position = _holdingTransform.position;

    }
    public void Sheath()
    {
        _twoHandedWeapon.transform.position = _sheathTransform.position;
    }
    void Update()
    {
        
    }
}

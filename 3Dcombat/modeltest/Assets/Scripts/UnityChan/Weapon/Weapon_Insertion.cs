using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Insertion : MonoBehaviour
{
    public BoxCollider _detectCollider;
    public Transform _weaponInsertPlace;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 12)
        {
            Debug.Log("ins " + gameObject.name);

            Weapon wp = other.transform.parent.GetComponent<Weapon>();
            if (!wp.Weapon_ThrowingOut.ReturningToHand && wp.Weapon_ThrowingOut.IsTraveling)
            {
                wp.StopMoving();
                Transform ptf = other.transform.parent.transform;
                ptf.SetParent(_weaponInsertPlace);
                ptf.localPosition = Vector3.zero;
                ptf.localRotation = Quaternion.identity;
            }

        }
    }
}

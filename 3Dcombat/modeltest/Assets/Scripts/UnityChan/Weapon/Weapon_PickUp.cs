using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_PickUp : MonoBehaviour
{
    private Weapon _weapon;
    [SerializeField] private Weapon_Placing _weapon_Placing;

    public void SetBelongingWeapon(Weapon wp)
    {
        _weapon = wp;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("pen");
             other.GetComponent<Player>().AddToNearbyWeapon(_weapon);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("pex");

            other.GetComponent<Player>().RemoveFromNearbyWeapon(_weapon);
        }
    }

}

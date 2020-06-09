using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackHitDetection : MonoBehaviour
{
    public float damage = 0.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hitplkayer");
            other.GetComponent<Player>().ReceiveDamage(damage);
        }
    }

}

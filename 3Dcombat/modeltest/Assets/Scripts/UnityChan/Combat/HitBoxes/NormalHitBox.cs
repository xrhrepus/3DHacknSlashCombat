using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalHitBox : MonoBehaviour
{
    public float damage;
    public float impact;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 10)
        {
            Debug.Log("NHN" + gameObject.name);
            var e = other.GetComponent<EnemyCtrl>();
            e.ReceiveDamage(damage);
            e.ReceiveImpact();

        }

    }
 

}

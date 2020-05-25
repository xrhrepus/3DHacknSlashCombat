using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalHitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 10)
        {
            Debug.Log("NHN" + gameObject.name);
        }

    }
 

}

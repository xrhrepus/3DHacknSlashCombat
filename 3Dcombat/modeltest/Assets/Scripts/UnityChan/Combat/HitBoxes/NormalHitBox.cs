using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalHitBox : MonoBehaviour
{
    public float damage;
    public float impact;
    public List<ParticleSystem> _particleSystems;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 10)
        {
            Debug.Log("NHN" + gameObject.name);
            foreach (var ps in _particleSystems)
            {
                ps.Play();
            }
            
            var e = other.GetComponent<EnemyCtrl>();
            e.ReceiveDamage(damage);
            e.ReceiveImpact();

        }

    }
 

}

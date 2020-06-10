using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalHitBox : MonoBehaviour
{
    public float damage;
    public float impact;
    public List<ParticleSystem> _particleSystems;
    public List<AudioSource> audioSources;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 10)
        {
            Debug.Log("NHN" + gameObject.name);
            foreach (var ps in _particleSystems)
            {
                ps.Play();
            }
            foreach (var au in audioSources)
            {
                au.Play();
            }
            var e = other.gameObject.GetComponent<EnemyCtrl>();
            if (e == null)
            {
                Debug.Log("err  " + other.name);
            }
            e.ReceiveDamage(damage);
            e.ReceiveImpact();

        }

    }
 

}

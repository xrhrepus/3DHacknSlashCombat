using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_HitByEffect : MonoBehaviour
{
    public List<ParticleSystem> _particleSystems;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            Weapon wp = other.transform.parent.GetComponent<Weapon>();
            if (/*!wp.Weapon_ThrowingOut.ReturningToHand &&*/ wp.Weapon_ThrowingOut.IsTraveling)
            {
                 foreach (var ps in _particleSystems)
                {
                    ps.Play();
                }
            }
        }

    }
}

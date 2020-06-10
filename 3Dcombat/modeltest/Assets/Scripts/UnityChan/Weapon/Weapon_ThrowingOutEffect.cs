using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_ThrowingOutEffect : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    public List<ParticleSystem> _particleSystems;
    private void Awake()
    {
        //_weapon = transform.parent.GetComponent<Weapon>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
 
            if (/*!wp.Weapon_ThrowingOut.ReturningToHand &&*/ _weapon.Weapon_ThrowingOut.IsTraveling)
            {
  
                foreach (var ps in _particleSystems)
                {
                    ps.Play();
                }
                string hitSFXName = "hit" + Random.Range(1, 3);
                _weapon.SFX_Weapon.PlaySFX(hitSFXName);
            }
        }

    }
}

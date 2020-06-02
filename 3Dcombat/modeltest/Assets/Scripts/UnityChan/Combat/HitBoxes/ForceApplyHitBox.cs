using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplyHitBox : MonoBehaviour
{
    public float forceMag = 1.0f;
    public Vector3 forceDir = Vector3.up;
    public ForceMode forceMode = ForceMode.Force;
    public float damage;

    public List<ParticleSystem> _particleSystems;

    public void SetForce(float mag,Vector3 fDir,ForceMode fmode)
    {
        forceMag = mag;
        forceDir = fDir;
        forceMode = fmode;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 10)
        {
            Debug.Log("FHN" + gameObject.name);
            foreach (var ps in _particleSystems)
            {
                ps.Play();
            }

            //forceDir = transform.forward;
            other.GetComponent<Rigidbody>().AddForce(forceDir * forceMag, forceMode);

            var e = other.GetComponent<EnemyCtrl>();
            e.ReceiveDamage(damage);
            e.ReceiveImpact();

        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_VFXControl : MonoBehaviour
{
    public List<ParticleSystem> _particleSystems;
    public void PlayEffects()
    {
        foreach (var ps in _particleSystems)
        {
            ps.Play();
        }
    }
}

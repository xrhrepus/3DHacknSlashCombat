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
    public void PlayEffect(string name)
    {
        
        foreach (var ps in _particleSystems)
        {
            if (ps.name == name)
            {
                ps.Play();
            }
        }
    }
    public void PlayEffect(int index)
    {
        _particleSystems[index].Play();
    }

}

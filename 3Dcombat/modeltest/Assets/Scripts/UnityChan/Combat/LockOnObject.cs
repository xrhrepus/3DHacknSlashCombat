using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnObject : MonoBehaviour
{
    //[SerializeField] private Sprite
    public ParticleSystem ParticleSystem;

    [SerializeField] private bool _isLockedOn = false;
    public bool isLockedOn { get => _isLockedOn; }

    public void LockedOn()
    {
        if (!_isLockedOn)
        {
            Debug.Log(name + " locked");
            _isLockedOn = true;
            ParticleSystem.Play();
        }
    }
    public void NotLockedOn()
    {
        if (_isLockedOn)
        {
            Debug.Log(name + " not locked");
            _isLockedOn = false;
            ParticleSystem.Stop();
            ParticleSystem.Clear();
        }
    }

 
}

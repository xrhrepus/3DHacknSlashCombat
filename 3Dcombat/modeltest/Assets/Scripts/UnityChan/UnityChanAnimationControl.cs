using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanAnimationControl : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        //animator
        _animator.GetComponent<Animator>();
    }
    public Animator GetAnimator()
    {
        return _animator;
    }
    public void SetParamInt(string paramName, int val)
    {
        _animator.SetFloat(paramName, val);
    }
    public void SetParamFloat(string paramName, float val)
    {
        _animator.SetFloat(paramName, val);
    }
    public void SetParamBool(string paramName, bool val)
    {
        _animator.SetBool(paramName, val);
    }
    public void SetParamTrigger(string paramName)
    {
        _animator.SetTrigger(paramName);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnDevice : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _detectAngle;
    private float _detectAngleCosine;
    [SerializeField] private LockOnObjectPool _lockOnObjectPool;
    private LockOnObject _currentLockOnObject;
    public LockOnObject CurrentLockOnObject { get => _currentLockOnObject; }
    private void Awake()
    {
        _detectAngleCosine = Mathf.Cos(_detectAngle * Mathf.Deg2Rad);
    }
    private void OnDrawGizmos()
    {
  
    }
    /// <summary>
    /// return a LockOnObject which most parallel with transform.forward inside of detectAngle
    /// </summary>
    /// <returns></returns>
    public LockOnObject FindLockObject()
    {
        LockOnObject target = null;
        float closestAngle = 0.0f; // 1.0 == parallel
        foreach (var lockObj in _lockOnObjectPool.LockOnObjects)
        {
            //if inside detect range
            //float cosAngle = Vector3.Dot(transform.forward.normalized, (lockObj.transform.position - transform.position).normalized);
            float cosAngle = Vector3.Dot(_player.CameraFocus._cam.transform.forward.normalized, (lockObj.transform.position - transform.position).normalized);

            if (cosAngle > _detectAngleCosine)
            {
                if (cosAngle > closestAngle)
                {
                    closestAngle = cosAngle;
                    target = lockObj;
                }
            }
        }
        //_currentLockOnObject?.NotLockedOn();
        //_currentLockOnObject = target;
        //target?.LockedOn();
        ChangeCurrentLockOnObject(target);
        return target;
    }
    private void ChangeCurrentLockOnObject(LockOnObject target)
    {
        if (target == _currentLockOnObject)
        {
            return;
        }
        _currentLockOnObject?.NotLockedOn();
        _currentLockOnObject = target;
        target?.LockedOn();
    }
    public void StopLockOn()
    {
        _currentLockOnObject?.NotLockedOn();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

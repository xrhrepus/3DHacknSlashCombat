using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnObjectPool : MonoBehaviour
{
    [SerializeField] private List<LockOnObject> _lockOnObjects = new List<LockOnObject>();
    public List<LockOnObject> LockOnObjects { get => _lockOnObjects; }
}

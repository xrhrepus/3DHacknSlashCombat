using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyNavigation : MonoBehaviour
{

    [SerializeField] private NavMeshAgent _navMeshAgent;
 
    [SerializeField] public Transform _to;

    public NavMeshAgent NavMeshAgent { get => _navMeshAgent; }

    public bool _stop = false;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        //_navMeshAgent.isStopped = _stop;
    }
    private void OnDisable()
    {
        _navMeshAgent.enabled = false;
    }
    void Update()
    {
    }
}

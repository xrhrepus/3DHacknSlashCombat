using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DummyEnemy : MonoBehaviour
{

    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private Transform _from;
    [SerializeField] private Transform _to;
    private Vector3 _destination;
    public bool _move = false;
    public bool toTo = true;
    private void Awake()
    {
        //_navMeshAgent = GetComponent<NavMeshAgent>();
        //_destination = _to.position;
        //_move = true;
        //_navMeshAgent.isStopped = _move;
    }
 
    void Update()
    {
        if (_move)
        {
            if (Vector3.Distance(transform.position, _destination) < 0.5f)
            {
                _destination = toTo ? _to.position : _from.position;
                _navMeshAgent.SetDestination(_destination);
                toTo = !toTo;
            }
        }

    }
}

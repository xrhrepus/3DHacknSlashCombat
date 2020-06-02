using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    private EnemyCtrl _enemyCtrl;

    public float _hp;
    public float _maxHp = 100.0f;

    public bool _readyToMove = true;
    public bool _moving = false;

    public bool _readyToAttack = true;
    public bool _attacking = false;
    public float _attackSpeed = 1.5f;
    private float _attackTimer = 0.0f;


    public bool _knockedBack = false;
    public float _knockedBackRecvTime = 1.0f;
    private float _knockedBackRecvTimer = 0.0f;
    public bool _alive = true;

    private void Awake()
    {
        _hp = _maxHp;
        _enemyCtrl = GetComponent<EnemyCtrl>();
    }
    private void Update()
    {
        if (_hp <= 0.0f)
        {
            _alive = false;
            return;
        }

        if (_attackTimer < _attackSpeed)
        {
            _attackTimer += Time.deltaTime;
        }

        if (_attacking && _attackTimer >= _attackSpeed)
        {
            _attackTimer = 0.0f;
            _readyToAttack = true;
        }

        if (_knockedBack && _knockedBackRecvTimer < _knockedBackRecvTime)
        {
            _knockedBackRecvTimer += Time.deltaTime;
            _enemyCtrl._enemyNavigation.NavMeshAgent.isStopped = true;

        }
        if (_knockedBackRecvTimer >= _knockedBackRecvTime)
        {
            _knockedBack = false;
            _readyToMove = true;
            _knockedBackRecvTimer = 0.0f;
            _enemyCtrl.RecoverFromImpact();
        }

    }

}

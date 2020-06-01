using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public EnemyNavigation _enemyNavigation;
    public EnemyAttack _enemyAttack;
    public EnemyStates _enemyStates;
    public Animator _animator;
    public Rigidbody _rigidbody;
    //recv damage
    public void ReceiveImpact()
    {
        _enemyStates._readyToMove = false;
        _enemyStates._knockedBack = true;
        _animator.SetTrigger("damaged");
    }

    public void KnockBack()
    {
        _animator.SetTrigger("knockBack");
    }

    public void ReceiveDamage(float dmg)
    {
        _enemyStates._hp -= dmg;
        
    }

    public void RecoverFromImpact()
    {
        _enemyStates._readyToMove = true;
 
    }
    //attack
    public void Attack()
    {
        if (!_enemyStates._readyToAttack)
        {
            return;
        }

        _animator.SetTrigger("attack");
    }


    //move
    public void Navigate()
    {
        if (!_enemyNavigation.NavMeshAgent.isStopped && _enemyStates._readyToMove)
        {
            if (Vector3.Distance(transform.position, _enemyNavigation._to.position) > 1.5f)
            {
                _enemyNavigation.NavMeshAgent.SetDestination(_enemyNavigation._to.position);
                _enemyStates._moving = true;
            }
            else
            {
                _enemyNavigation.NavMeshAgent.isStopped = true;
                _enemyStates._moving = false;
                _enemyStates._attacking = true;
            }
        }


    }
     

    private void Awake()
    {
        _enemyNavigation = GetComponent<EnemyNavigation>();
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyStates = GetComponent<EnemyStates>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _enemyNavigation.NavMeshAgent.SetDestination(_enemyNavigation._to.position);
        _enemyNavigation.NavMeshAgent.isStopped = false;
        _enemyStates._moving = true;

    }
    private void Update()
    {
        if (_enemyStates._alive == false)
        {
            _animator.SetBool("alive", false);
            _enemyNavigation.NavMeshAgent.isStopped = true;
            _rigidbody.velocity = Vector3.zero;
            return;
        }

        if (_enemyStates._moving)
        {
            Navigate();
             _animator.SetFloat("speed", _enemyNavigation.NavMeshAgent.velocity.magnitude);
            //return;
        }
        if (_enemyStates._attacking)
        {
            Attack();
        }
        //if (!_enemyStates._knockedBack)
        //{
        //    RecoverFromImpact();
        //}
    }
}

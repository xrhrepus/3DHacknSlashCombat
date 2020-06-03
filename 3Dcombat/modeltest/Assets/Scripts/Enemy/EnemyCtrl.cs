﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public EnemyNavigation _enemyNavigation;
    public EnemyAttack _enemyAttack;
    public EnemyStates _enemyStates;
    public Animator _animator;
    public Rigidbody _rigidbody;

    public List<ParticleSystem> _getHitPS;

    //recv damage
    public void ReceiveImpact()
    {
        if (!_enemyStates._knockedBack)
        {
            _enemyStates._readyToMove = false;
            _enemyStates._knockedBack = true;
            //_animator.SetTrigger("damaged");
        }
        foreach (var ps in _getHitPS)
        {
            ps.Play();
        }
            _animator.Play("Damage", 0);
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
        _enemyNavigation.NavMeshAgent.isStopped = false;


    }
    //attack
    public void Attack()
    {
        if (!_enemyStates._readyToAttack)
        {
            return;
        }
        if (Vector3.Distance(transform.position, _enemyNavigation._to.position) > _enemyAttack._attackRange)
        {
            _enemyNavigation.NavMeshAgent.SetDestination(_enemyNavigation._to.position);
            _enemyStates._moving = true;
            _enemyNavigation.NavMeshAgent.isStopped = false;
            return;
        }
        Debug.Log("atk");
        _animator.SetTrigger("attack");
        _enemyStates._readyToAttack = false;
    }


    //move
    public void Navigate()
    {
        if (!_enemyNavigation.NavMeshAgent.isStopped && _enemyStates._readyToMove)
        {
            if (Vector3.Distance(transform.position, _enemyNavigation._to.position) > _enemyAttack._attackRange)
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
            foreach (var bc in GetComponents<BoxCollider>())
            {
                bc.enabled = false;
            }
            _enemyNavigation.enabled = false;
            _enemyStates.enabled = false;
            //_rigidbody.useGravity = false;
            _rigidbody.freezeRotation = true;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
            this.enabled = false;
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
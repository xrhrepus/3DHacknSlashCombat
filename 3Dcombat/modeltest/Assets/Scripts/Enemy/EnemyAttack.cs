using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyCtrl _enemyCtrl;

    public float _attackRange = 2.0f;
    private void Awake()
    {
        _enemyCtrl = GetComponent<EnemyCtrl>();
    }



}

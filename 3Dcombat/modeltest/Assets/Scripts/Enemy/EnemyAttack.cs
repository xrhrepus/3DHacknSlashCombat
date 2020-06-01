using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyCtrl _enemyCtrl;

    private void Awake()
    {
        _enemyCtrl = GetComponent<EnemyCtrl>();
    }



}

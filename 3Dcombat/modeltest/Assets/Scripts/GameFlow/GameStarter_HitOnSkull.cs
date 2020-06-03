using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter_HitOnSkull : MonoBehaviour
{
    [SerializeField] private GameStarter _gameStarter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            _gameStarter.GameStart();
            this.enabled = false;
        }

    }
}

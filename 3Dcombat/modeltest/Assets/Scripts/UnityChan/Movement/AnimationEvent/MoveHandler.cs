using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    [SerializeField]
    private MovementBehavior _movementBehavior;
    [SerializeField] private Player _player;

    public void FootL()
    { }
    public void FootR()
    { }

    public void DodgeRollStart()
    {
        _movementBehavior.DodgeMovement();
        _player.SheathWeapon();
    }
    public void DodgeRollComplete()
    {
 
        _movementBehavior.DodgeCompelete();
    }


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    [SerializeField]
    private MovementBehavior _movementBehavior;

    public void FootL()
    { }
    public void FootR()
    { }
    public void DodgeRollComplete()
    {
    
        _movementBehavior.DodgeCompelete();
    }
}

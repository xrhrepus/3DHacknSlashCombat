using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    //ref to Player
    private Player _player;

    //make use of MovementBehavior
    [Header("MovementBehavior")]
    [SerializeField] private MovementBehavior _movementBehavior;
 
    public void MovePerformed(Vector2 val)
    {
        _movementBehavior.SetMoveValue(val);
    }
    public void JumpPerformed()
    {
        _movementBehavior.JumpPerformed();
    }
    public void DodgePerformed()
    {
        _movementBehavior.DodgePerformed();
    }


    private void Awake()
    {
        _player = GetComponent<Player>();

    }

}

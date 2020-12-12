using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Knight_AbilityState
{
    //bool
    [SerializeField]
    private bool isIdling = false;
    public bool IsIdling { get => isIdling; set => isIdling = value; }

    [SerializeField]
    private bool isMoving = false;
    public bool IsMoving { get => isMoving; set => isMoving = value; }

    [SerializeField]
    private bool isOnGround = false;
    public bool IsOnGround { get => isOnGround; set => isOnGround = value; }
 
    [SerializeField]
    private bool isAttacking = false;
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }


    public bool CanAttack { get; set; }
    public bool CanMove { get; set; }
    public bool CanJump { get; set; }


}

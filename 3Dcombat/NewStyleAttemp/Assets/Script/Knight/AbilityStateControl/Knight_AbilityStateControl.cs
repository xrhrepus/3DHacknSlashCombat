using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_AbilityStateControl : MonoBehaviour
{
    [SerializeField]
    private Knight_AbilityState _knightAbilityState;

    private void Awake()
    {
        
    }

    public void MoveForwardPress()
    { }
    public void MoveBackwardPress()
    { }
    public void MoveLeftPress()
    { }
    public void MoveRightPress()
    { }
    public void AttackPress()
    { }

    public void AttackHold()
    { }

    public void AttackRelease()
    { }

}

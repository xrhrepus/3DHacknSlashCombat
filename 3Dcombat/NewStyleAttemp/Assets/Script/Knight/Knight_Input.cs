using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Input : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;
    public InputCtrl.PlayerActions KnightInputCtrl { get => _playerInput.InputCtrl.Player; } 
 
}

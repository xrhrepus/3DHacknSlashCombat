using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control params of animator
/// </summary>
public class Knight_AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private Knight_AbilityState _knight_AbilityState;

    [SerializeField]
    private List<string> _stateNames;

    private void Awake()
    {
        _stateNames.Add(_knight_AbilityState.IsAttacking.ToString());
    }

}

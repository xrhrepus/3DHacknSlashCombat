using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField]
    private Knight_Input _knightInput;
    public Knight_Input KnightInput { get=> _knightInput; }
    [SerializeField]
    private Knight_Transform _knightTransform;
    public Knight_Transform KnightTransform { get => _knightTransform; }
    [SerializeField]
    private Knight_Animation _knightAnimation;
    public Knight_Animation KnightAnimation { get => _knightAnimation; }
    [SerializeField]
    private Knight_AbilityList _knightAbilityList;
    public Knight_AbilityList KnightAbilityList { get => _knightAbilityList; }

    [SerializeField]
    private ThirdPersonOrbitCamBasic _camera;
    public ThirdPersonOrbitCamBasic Camera { get=> _camera; }
 
}

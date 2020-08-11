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
    private Knight_Ability _knightAbility;
    public Knight_Ability KnightAbility { get => _knightAbility; }
    

    void Start()
    {
        
    }

     void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField]
    private KnightCtrl _knightCtrl;
    public KnightCtrl KnightCtrl { get=> _knightCtrl;}
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

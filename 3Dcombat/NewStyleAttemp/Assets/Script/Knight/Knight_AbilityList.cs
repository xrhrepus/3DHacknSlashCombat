using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_AbilityList : MonoBehaviour
{
    [SerializeField]
    private Knight _knight;
    public Knight Knight { get => _knight; }

    private KnightAbility[] abilityBehaviours;

    private void Awake()
    {
        abilityBehaviours = Knight.KnightAnimation.Animator.GetBehaviours<KnightAbility>();
        foreach (var ab in abilityBehaviours)
        {
            ab.Knight = Knight;
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

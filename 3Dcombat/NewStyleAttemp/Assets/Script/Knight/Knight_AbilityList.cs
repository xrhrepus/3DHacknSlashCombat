using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_AbilityList : MonoBehaviour
{
    [SerializeField]
    private Knight _knight;
    public Knight Knight { get => _knight; }

    private void Awake()
    {
        var abilityBehaviour = Knight.KnightAnimation.Animator.GetBehaviours<KnightAbility>();
        foreach (var ab in abilityBehaviour)
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

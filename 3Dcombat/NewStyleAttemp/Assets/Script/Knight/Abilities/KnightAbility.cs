using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KnightAbility : StateMachineBehaviour
{
    [SerializeField]
    private Knight _knight;
    public Knight Knight { get; set; }


}

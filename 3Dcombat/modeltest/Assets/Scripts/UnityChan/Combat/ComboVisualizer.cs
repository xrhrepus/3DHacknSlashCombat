using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboVisualizer : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator _animator;

    //0 ~ 1
    public float currentProgress { get; set; }

    
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Attributes : MonoBehaviour
{
    [SerializeField] private Image _hpBar;

    [SerializeField] public float _maxHp = 100.0f;
    [SerializeField] private float _currentHp = 0.0f;
    //public float MaxHp { get=> _maxHp; }
    public float CurrentHp { get=> _currentHp; set { _currentHp = value; UpdateHPBar(); } }

    private void Awake()
    {
        CurrentHp = _maxHp;
    }

    private void UpdateHPBar()
    {
        
        _hpBar.fillAmount = _currentHp / _maxHp;
    }

    private void Update()
    {
    }

}

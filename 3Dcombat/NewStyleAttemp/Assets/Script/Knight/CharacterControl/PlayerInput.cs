using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputCtrl _inputCtrl;
    public InputCtrl InputCtrl { get => _inputCtrl; }
    private void OnEnable()
    {
        _inputCtrl.Enable();
    }
    private void OnDisable()
    {
        _inputCtrl.Disable();
    }

    private void Awake()
    {
        _inputCtrl = new InputCtrl();
    }

}

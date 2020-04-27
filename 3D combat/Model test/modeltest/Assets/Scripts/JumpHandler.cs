using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    public InputCtrl _inputCtrl;

    public void JumpUpEvent()
    {
        _inputCtrl.Jump();
    }
}

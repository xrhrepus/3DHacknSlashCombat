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

    public void JumpLandEvent()
    {
        _inputCtrl.JumpLanding();
    }
    public void ReadyToJumpEvent()
    {
        _inputCtrl.ReadyToJump(true);
    }
    public void NotReadyToJumpEvent()
    {
        _inputCtrl.ReadyToJump(false);
    }
}

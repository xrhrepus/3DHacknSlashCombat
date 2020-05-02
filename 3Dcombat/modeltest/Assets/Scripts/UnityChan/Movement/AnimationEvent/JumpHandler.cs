using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    public MovementBehavior _movementBehavior;

    public void JumpUpEvent()
    {
        _movementBehavior.Jump();
    }

    public void JumpLandEvent()
    {
        _movementBehavior.JumpLanding();
    }
    public void ReadyToJumpEvent()
    {
        _movementBehavior.ReadyToJump(true);
    }
    public void NotReadyToJumpEvent()
    {
        _movementBehavior.ReadyToJump(false);
    }
}

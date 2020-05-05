using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    [SerializeField]
    private MovementBehavior _movementBehavior;

    public void JumpUpEvent()
    {
        _movementBehavior.JumpUp();
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

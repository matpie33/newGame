using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class JumpingState : State
{

    public State DuringState(DaleStateHandler daleStateHandler)
    {

        if (daleStateHandler.characterController.isGrounded && !daleStateHandler.verticalMovementController.IsJumpInProgress())
        {
            return daleStateHandler.walkingState;
        }
        if (daleStateHandler.ledgeDetectionState.IsThereWall && daleStateHandler.ledgeDetectionState.IsThereSpaceToClimb)
        {
            return daleStateHandler.grabbingLedgeState;
        }
        return this;
    }

    public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
    {
        Animator animator = daleStateHandler.animator;

        animator.SetBool("jump", true);
        animator.SetBool("movingBackward", false);
        daleStateHandler.audioManager.ToggleSound("daleJumpSound", true);
        daleStateHandler.horizontalMovementController.SetRespondingToArrowKeys(false);
        daleStateHandler.horizontalMovementController.KeepHorizontalSpeed(true);
        daleStateHandler.verticalMovementController.JumpToAir();
    }
}

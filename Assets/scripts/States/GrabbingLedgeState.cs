using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GrabbingLedgeState : State
{
    private bool grabbingAnimationFinished;
    private bool climbingAnimationFinished;

    public State DuringState(DaleStateHandler daleStateHandler)
    {
        if (grabbingAnimationFinished && daleStateHandler.keyboardController.IsJumpKeyPressed)
        {
            grabbingAnimationFinished = false;
            daleStateHandler.animator.SetBool("climbLedge", true);
            daleStateHandler.animator.SetBool("isGrabbing", false);
            daleStateHandler.animator.applyRootMotion = true;
            daleStateHandler.movementController.enabled = false;
        }
        if (climbingAnimationFinished)
        {
            climbingAnimationFinished = false;
            daleStateHandler.animator.SetBool("climbLedge", false);
            daleStateHandler.movementController.enabled = true;
            daleStateHandler.animator.applyRootMotion = false;

            return daleStateHandler.walkingState;
        }
        return this;
    }

    public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
    {
        daleStateHandler.animator.SetBool("isGrabbing", true);
        daleStateHandler.movementController.SetVerticalMovementEnabled(false);
        daleStateHandler.gravityHandler.StopJump();
    }

    public void OnGrabbingAnimationFinished()
    {
        grabbingAnimationFinished = true;
    }
    public void OnClimbingAnimationFinished()
    {
        climbingAnimationFinished = true;
    }




}

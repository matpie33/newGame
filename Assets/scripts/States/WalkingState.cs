using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class WalkingState : State
{

    public State DuringState(DaleStateHandler daleStateHandler)
    {
        KeyboardController keyboardController = daleStateHandler.keyboardController;
        if (keyboardController.IsJumpKeyPressed)
        {
            return daleStateHandler.jumpingState;
        }
        if (keyboardController.IsPickupOrReleaseObjectsKeyPressed && daleStateHandler.pickingUpObjectsHandler.ObjectToPickup != null)
        {
            return daleStateHandler.pickupObjectsState;
        }
        return this;
    }

    public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
    {
        if (previousState.Equals(daleStateHandler.grabbingLedgeState))
        {
            daleStateHandler.movementController.SetVerticalMovementEnabled(true);
            daleStateHandler.animator.SetBool("climbLedge", false);

        }
        daleStateHandler.movementController.IsHorizontalMovementEnabled = true;
        daleStateHandler.animator.SetBool("jump", false);

    }
}

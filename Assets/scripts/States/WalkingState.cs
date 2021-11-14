﻿using System;
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
        if (keyboardController.IsPickupOrReleaseObjectsKeyPressed && daleStateHandler.pickingUpObjectsHandler.objectToPickup != null)
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
        daleStateHandler.objectsOnTheFloorDetector.SetActive(true);
        daleStateHandler.horizontalMovementController.SetRespondingToArrowKeys(true);
        daleStateHandler.horizontalMovementController.KeepHorizontalSpeed(false);
        daleStateHandler.characterController.enabled = true;
        daleStateHandler.animator.SetBool("jump", false);

    }
}

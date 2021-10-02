using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.States
{
    class WalkingState : State
    {

        public State DuringState(DaleStateHandler daleStateHandler)
        {
            KeyboardController keyboardController = daleStateHandler.keyboardController;
            if (keyboardController.isJumpKeyPressed)
            {
                return daleStateHandler.jumpingState;
            }
            if (keyboardController.isPickupOrReleaseObjectsKeyPressed)
            {
                return daleStateHandler.pickupObjectsState;
            }
            return this;
        }

        public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
        {
            if (previousState.Equals(daleStateHandler.grabbingLedgeState))
            {
                daleStateHandler.gravityHandler.enabled = true;
                daleStateHandler.animator.SetBool("climbLedge", false);

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts.States
{
    class GrabbingLedgeState : State
    {

        public State DuringState(DaleStateHandler daleStateHandler)
        {
            if (daleStateHandler.keyboardController.isJumpKeyPressed)
            {
                return daleStateHandler.climbingLedgeState;
            }
            return this;
        }

        public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
        {
            daleStateHandler.animator.SetBool("isGrabbing", true);
            daleStateHandler.gravityHandler.enabled = false;
            daleStateHandler.gravityHandler.StopJump();
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts.States
{
    class ClimbingLedgeState : State
    {
        private bool climbingAnimationFinished;

        public State DuringState(DaleStateHandler daleStateHandler)
        {
            if (climbingAnimationFinished)
            {
                climbingAnimationFinished = false;
                daleStateHandler.animator.SetBool("climbLedge", false);
                daleStateHandler.animator.SetBool("isGrabbing", false);
                daleStateHandler.gravityHandler.enabled = true;
                return daleStateHandler.walkingState;
            }
            return this;
        }

        public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
        {
            daleStateHandler.animator.SetBool("climbLedge", true);
            daleStateHandler.animator.SetBool("isGrabbing", false);
        }

        public void OnClimbingAnimationFinished()
        {
            climbingAnimationFinished = true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts.States
{
    class GrabbingLedgeState : State
    {
        private bool grabbingAnimationFinished;
        private bool climbingAnimationFinished;

        public State DuringState(DaleStateHandler daleStateHandler)
        {
            if (grabbingAnimationFinished && daleStateHandler.keyboardController.IsJumpKeyPressed)
            {
                grabbingAnimationFinished = false;
                daleStateHandler.Animator.SetBool("climbLedge", true);
                daleStateHandler.Animator.SetBool("isGrabbing", false);
                daleStateHandler.Animator.applyRootMotion = true;
            }
            if (climbingAnimationFinished)
            {
                climbingAnimationFinished = false;
                daleStateHandler.Animator.applyRootMotion = false;
                return daleStateHandler.walkingState;
            }
            return this;
        }

        public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
        {
            daleStateHandler.Animator.SetBool("isGrabbing", true);
            daleStateHandler.gravityHandler.enabled = false;
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



}

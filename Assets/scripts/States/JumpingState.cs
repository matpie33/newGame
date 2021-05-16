using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.States
{
    class JumpingState : State
    {



        public State DuringState(DaleStateHandler daleStateHandler)
        {

            if (daleStateHandler.characterController.isGrounded)
            {
                return daleStateHandler.walkingState;
            }
            if (daleStateHandler.ledgeDetectionState.isThereWall && daleStateHandler.ledgeDetectionState.isThereSpaceToClimb)
            {
                return daleStateHandler.grabbingLedgeState;
            }
            return this;
        }

        public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
        {
            Animator animator = daleStateHandler.animator;
            ThirdPersonMovement thirdPersonMovement = daleStateHandler.thirdPersonMovement;
            GravityHandler gravityHandler = daleStateHandler.gravityHandler;
            gravityHandler.Jump();
            Debug.Log("jumping transition");
            animator.SetBool("jump", true);
            animator.SetBool("run", false);
            thirdPersonMovement.enabled = false;
        }
    }
}

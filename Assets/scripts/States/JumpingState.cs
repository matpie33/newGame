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
            if (daleStateHandler.ledgeDetectionState.IsThereWall && daleStateHandler.ledgeDetectionState.IsThereSpaceToClimb)
            {
                return daleStateHandler.grabbingLedgeState;
            }
            return this;
        }

        public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
        {
            Animator animator = daleStateHandler.animator;
            MovementController movementController = daleStateHandler.movementController;
            movementController.Jump();
            Debug.Log("jumping transition");
            animator.SetBool("jump", true);
            animator.SetBool("run", false);
            animator.SetBool("movingBackward", false);
            movementController.IsHorizontalMovementEnabled = false;
        }
    }
}

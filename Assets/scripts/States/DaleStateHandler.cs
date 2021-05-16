using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.States
{
    class DaleStateHandler : MonoBehaviour
    {

        public GrabbingLedgeState grabbingLedgeState { get; private set; }
        public JumpingState jumpingState { get; private set; }
        public WalkingState walkingState { get; private set; }
        public ClimbingLedgeState climbingLedgeState { get; private set; }
        public KeyboardController keyboardController { get; private set; }
        public CharacterController characterController { get; private set; }
        public ThirdPersonMovement thirdPersonMovement { get; private set; }
        public Animator animator { get; private set; }
        public GravityHandler gravityHandler { get; private set; }
        public LedgeDetectionState ledgeDetectionState { get; private set; }

        private State currentState;

        void Start()
        {
            keyboardController = FindObjectOfType<KeyboardController>();
            characterController = FindObjectOfType<CharacterController>();
            gravityHandler = FindObjectOfType<GravityHandler>();
            thirdPersonMovement = FindObjectOfType<ThirdPersonMovement>();
            animator = FindObjectOfType<Animator>();
            ledgeDetectionState = FindObjectOfType<LedgeDetectionState>();

            grabbingLedgeState = new GrabbingLedgeState();
            jumpingState = new JumpingState();
            walkingState = new WalkingState();
            climbingLedgeState = new ClimbingLedgeState();
            currentState = walkingState;
        }

        public void Update()
        {
            State newState = currentState.DuringState(this);
            if (newState != currentState)
            {
                newState.OnTransition(currentState, this);
                currentState = newState;
            }

        }

    }


}

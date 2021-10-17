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
        public KeyboardController keyboardController { get; private set; }
        public CharacterController characterController { get; private set; }
        public ThirdPersonMovement thirdPersonMovement { get; private set; }

        public GravityHandler gravityHandler { get; private set; }
        public LedgeDetectionState ledgeDetectionState { get; private set; }
        public PickingUpObjectsState pickupObjectsState { get; private set; }
        public ReleasingObjectsState releasingObjectsState { get; private set; }
        public ThrowingObjectsState throwingObjectsState { get; private set; }
        public HoldingObjectState holdingObjectState { get; private set; }

        public Animator Animator { get; private set; }

        public PickingUpObjectsHandler PickingUpObjectsHandler;

        private State currentState;

        void Start()
        {
            keyboardController = FindObjectOfType<KeyboardController>();
            characterController = FindObjectOfType<CharacterController>();
            gravityHandler = FindObjectOfType<GravityHandler>();
            thirdPersonMovement = FindObjectOfType<ThirdPersonMovement>();
            PickingUpObjectsHandler = GetComponent<PickingUpObjectsHandler>();
            ledgeDetectionState = FindObjectOfType<LedgeDetectionState>();

            grabbingLedgeState = new GrabbingLedgeState();
            jumpingState = new JumpingState();
            walkingState = new WalkingState();
            pickupObjectsState = new PickingUpObjectsState();
            releasingObjectsState = new ReleasingObjectsState();
            holdingObjectState = new HoldingObjectState();
            throwingObjectsState = new ThrowingObjectsState();
            currentState = walkingState;
            Animator = GetComponent<Animator>();

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

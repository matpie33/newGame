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
        public Animator animator { get; private set; }
        public GravityHandler gravityHandler { get; private set; }
        public LedgeDetectionState ledgeDetectionState { get; private set; }
        public PickingUpObjectsState pickupObjectsState { get; private set; }
        public ReleasingObjectsState releasingObjectsState { get; private set; }
        public HoldingObjectState holdingObjectState { get; private set; }

        public GameObject ObjectToPickup { get; set; }

        public GameObject ParentPositionObject;

        public RigsHandler RigsHandler { get; private set; }

        public BoxCollider ObjectsInFrontDetectingCollider;

        private State currentState;
        private bool IsPickingUpObject;

        void Start()
        {
            keyboardController = FindObjectOfType<KeyboardController>();
            characterController = FindObjectOfType<CharacterController>();
            gravityHandler = FindObjectOfType<GravityHandler>();
            thirdPersonMovement = FindObjectOfType<ThirdPersonMovement>();
            animator = GetComponent<Animator>();
            ledgeDetectionState = FindObjectOfType<LedgeDetectionState>();

            grabbingLedgeState = new GrabbingLedgeState();
            jumpingState = new JumpingState();
            walkingState = new WalkingState();
            pickupObjectsState = new PickingUpObjectsState();
            releasingObjectsState = new ReleasingObjectsState();
            holdingObjectState = new HoldingObjectState();
            currentState = walkingState;
            RigsHandler = GetComponent<RigsHandler>();
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

        public void SetPickingUpObject()
        {
            IsPickingUpObject = true;
        }

        public bool GetIsPickingUpObject()
        {
            return IsPickingUpObject;
        }

    }


}

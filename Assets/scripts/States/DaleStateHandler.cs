using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class DaleStateHandler : MonoBehaviour
{
    public PredictedTrajectoryCalculator predictedTrajectoryCalculator { get; private set; }
    public GrabbingLedgeState grabbingLedgeState { get; private set; }
    public JumpingState jumpingState { get; private set; }
    public WalkingState walkingState { get; private set; }
    public KeyboardController keyboardController { get; private set; }
    public CharacterController characterController { get; private set; }
    public DaleMovementController movementController { get; private set; }


    public HorizontalMovementController horizontalMovementController { get; private set; }

    public VerticalMovementController verticalMovementController { get; private set; }
    public LedgeDetectionState ledgeDetectionState { get; private set; }
    public PickingUpObjectsState pickupObjectsState { get; private set; }
    public ReleasingObjectsState releasingObjectsState { get; private set; }
    public ThrowingObjectsState throwingObjectsState { get; private set; }
    public HoldingObjectState holdingObjectState { get; private set; }


    public Animator animator { get; private set; }

    public PickingUpObjectsController pickingUpObjectsHandler { get; private set; }

    public AudioManager audioManager;

    public GameObject objectsOnTheFloorDetector;

    private State currentState;


    void Start()
    {
        keyboardController = FindObjectOfType<KeyboardController>();
        characterController = FindObjectOfType<CharacterController>();
        movementController = FindObjectOfType<DaleMovementController>();
        pickingUpObjectsHandler = GetComponent<PickingUpObjectsController>();
        ledgeDetectionState = FindObjectOfType<LedgeDetectionState>();
        verticalMovementController = GetComponent<VerticalMovementController>();
        horizontalMovementController = GetComponent<HorizontalMovementController>();
        predictedTrajectoryCalculator = GetComponent<PredictedTrajectoryCalculator>();
        audioManager = FindObjectOfType<AudioManager>();

        grabbingLedgeState = new GrabbingLedgeState();
        jumpingState = new JumpingState();
        walkingState = new WalkingState();
        pickupObjectsState = new PickingUpObjectsState();
        releasingObjectsState = new ReleasingObjectsState();
        holdingObjectState = new HoldingObjectState();
        throwingObjectsState = new ThrowingObjectsState();
        currentState = walkingState;
        animator = GetComponent<Animator>();

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

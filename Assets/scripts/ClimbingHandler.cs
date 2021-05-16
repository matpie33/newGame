using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingHandler : MonoBehaviour
{
    private LedgeDetectionState ledgeDetectionState;
    private ThirdPersonMovement thirdPersonMovement;
    private Animator animator;
    private GravityHandler gravityHandler;
    private CurrentDaleState currentDaleState;


    void Start()
    {
        thirdPersonMovement = FindObjectOfType<ThirdPersonMovement>();
        animator = FindObjectOfType<Animator>();
        ledgeDetectionState = FindObjectOfType<LedgeDetectionState>();
        gravityHandler = FindObjectOfType<GravityHandler>();
        currentDaleState = FindObjectOfType<CurrentDaleState>();
    }

    void Update()
    {
        if (ledgeDetectionState.isThereWall && ledgeDetectionState.isThereSpaceToClimb)
        {
            Debug.Log("grabb ledge");
            animator.SetBool("isGrabbing", true);
            gravityHandler.enabled = false;
            gravityHandler.StopJump();
            currentDaleState.UpdateState(DaleStates.GRABBING_LEDGE);
            Debug.Log("is grabbing");

        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    private Animator animator;
    private GravityHandler gravityHandler;
    private CurrentDaleState currentDaleState;


    void Start()
    {
        animator = FindObjectOfType<Animator>();
        gravityHandler = FindObjectOfType<GravityHandler>();
        currentDaleState = FindObjectOfType<CurrentDaleState>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DaleStates daleStates = currentDaleState.GetState();
            if (daleStates.Equals(DaleStates.WALKING))
            {
                gravityHandler.Jump();
                Debug.Log("set jump true");

            }
            if (daleStates.Equals(DaleStates.GRABBING_LEDGE))
            {
                gravityHandler.ClimbUpLedge();
                animator.SetBool("climbLedge", true);
                animator.SetBool("isGrabbing", false);

            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("test", true);
            GetComponent<ThirdPersonMovement>().enabled = false;
            //GetComponent<CharacterController>().Move(Vector3.zero);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{

    private CharacterController controller;
    private Animator animator;
    private float verticalVelocity;
    private float gravity = 4f;
    public float jumpForce = 5f;
    private bool gravityEnabled = true;
    private bool isJumping;
    private LedgeDetectionState ledgeDetectionState;
    private bool isClimbingWall = false;
    private ThirdPersonMovement thirdPersonMovement;

    void Start()
    {
        controller = FindObjectOfType<CharacterController>();
        animator = FindObjectOfType<Animator>();
        ledgeDetectionState = FindObjectOfType<LedgeDetectionState>();
        thirdPersonMovement = FindObjectOfType<ThirdPersonMovement>();
    }


    public void setGravityEnabled(bool enabled)
    {
        gravityEnabled = enabled;
        if (!gravityEnabled)
        {
            verticalVelocity = 0;
        }
    }

    void Update()
    {
        Vector3 movementDirection = thirdPersonMovement.GetCurrentMovementDirection();
        float verticalSpeed = CalculateVerticalSpeed();
        movementDirection.y = verticalSpeed * 0.1f;
        controller.Move(movementDirection);
        if (controller.isGrounded)
        {
            isJumping = false;
            thirdPersonMovement.enabled = true;
        }
    }



    public float CalculateVerticalSpeed()
    {
        if (!gravityEnabled)
        {
            return 0;
        }

        if (controller.isGrounded)
        {
            

            verticalVelocity = -gravity * Time.deltaTime;
            if (isJumping)
            {
                Debug.Log("set jump to false");
                verticalVelocity = jumpForce;
                isJumping = false;
            }
        }
        else
        {
            Debug.Log("not grounded");
            verticalVelocity -= gravity * Time.deltaTime;
        }

        return verticalVelocity;

    }

    public void ClimbUpLedge()
    {
        isClimbingWall = true;
    }

    public void Jump()
    {
        Debug.Log("jump");
        isJumping = true;
        animator.SetBool("jump", false);
        animator.SetBool("run", false);
        thirdPersonMovement.enabled = false;

    }

    public void StopJump()
    {
        isJumping = false;

    }

}

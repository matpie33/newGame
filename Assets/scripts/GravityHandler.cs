using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{

    private CharacterController controller;
    private float verticalVelocity;
    private float gravity = 4f;
    public float jumpForce = 5f;
    private bool gravityEnabled = true;
    private bool jumpTriggered;
    private ThirdPersonMovement thirdPersonMovement;

    void Start()
    {
        controller = FindObjectOfType<CharacterController>();
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
            jumpTriggered = false;
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
            if (jumpTriggered)
            {
                verticalVelocity = jumpForce;
                jumpTriggered = false;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        return verticalVelocity;

    }


    public void Jump()
    {
        jumpTriggered = true;


    }

    public void StopJump()
    {
        verticalVelocity = 0;

    }

}

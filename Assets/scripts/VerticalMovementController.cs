using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovementController : MonoBehaviour
{

    private CharacterController controller;
    private float verticalVelocity;
    public float gravity = 4f;
    public float jumpForce = 5f;
    private bool jumpTriggered;

    public void Start()
    {
        controller = FindObjectOfType<CharacterController>();
    }




    public float GetVerticalMovement()
    {
        float verticalSpeed = CalculateVerticalSpeed() * 0.1f;
        if (controller.isGrounded)
        {
            jumpTriggered = false;

        }
        return verticalSpeed;
    }



    public float CalculateVerticalSpeed()
    {
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

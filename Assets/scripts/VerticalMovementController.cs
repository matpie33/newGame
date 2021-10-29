using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovementController : MonoBehaviour
{

    private CharacterController character;
    private float verticalVelocity;
    [SerializeField]
    private float gravity = 4f;
    [SerializeField]
    private float jumpForce = 5f;
    private bool jumpTriggered;

    public void Start()
    {
        character = FindObjectOfType<CharacterController>();
    }

    public float GetVerticalMovement()
    {
        float verticalSpeed = CalculateVerticalSpeed() * 0.1f;
        if (character.isGrounded)
        {
            jumpTriggered = false;

        }
        return verticalSpeed;
    }



    public float CalculateVerticalSpeed()
    {
        if (character.isGrounded)
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

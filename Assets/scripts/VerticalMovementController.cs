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

    private JumpStatus jumpStatus;

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
            if (jumpStatus.Equals(JumpStatus.IN_AIR))
            {
                verticalVelocity = jumpForce;
                jumpTriggered = false;
                jumpStatus = JumpStatus.FINISHED;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        return verticalVelocity;

    }



    public void PrepareToJump()
    {
        jumpStatus = JumpStatus.PREPARING;
    }

    public void StopJump()
    {
        verticalVelocity = 0;

    }

    public bool IsJumpInProgress()
    {
        return !jumpStatus.Equals(JumpStatus.FINISHED);
    }

    public void JumpToAir()
    {
        jumpStatus = JumpStatus.IN_AIR;
    }

}

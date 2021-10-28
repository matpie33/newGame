using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private ThirdPersonMovement thirdPersonMovement;

    private GravityHandler gravityHandler;

    private CharacterController characterController;

    public bool IsHorizontalMovementEnabled { get; set; }
    public bool IsVerticalMovementEnabled { get; set; }

    void Start()
    {
        thirdPersonMovement = GetComponent<ThirdPersonMovement>();
        gravityHandler = GetComponent<GravityHandler>();
        characterController = FindObjectOfType <CharacterController>();
        IsHorizontalMovementEnabled = true;
        IsVerticalMovementEnabled = true;

    }

    void Update()
    {

        Vector3 vectorToMove = Vector3.zero;
        if (IsHorizontalMovementEnabled)
        {
            Vector3 horizontalMovement = thirdPersonMovement.CalculateHorizontalMovement();
            vectorToMove.x = horizontalMovement.x;
            vectorToMove.z = horizontalMovement.z;
        }
        if (IsVerticalMovementEnabled)
        {
            vectorToMove.y = gravityHandler.GetVerticalMovement();
        }
        characterController.Move(vectorToMove);
        
    }

    public void Jump()
    {
        gravityHandler.Jump();
    }

}

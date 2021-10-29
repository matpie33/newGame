using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private HorizontalMovementController horizontalMovementController;

    private VerticalMovementController verticalMovementController;

    private CharacterController characterController;

    public bool IsHorizontalMovementEnabled { get; set; }
    [SerializeField]
    private bool isVerticalMovementEnabled;


    void Start()
    {
        horizontalMovementController = GetComponent<HorizontalMovementController>();
        verticalMovementController = GetComponent<VerticalMovementController>();
        characterController = FindObjectOfType<CharacterController>();
        IsHorizontalMovementEnabled = true;
        isVerticalMovementEnabled = true;

    }

    void Update()
    {

        Vector3 vectorToMove = Vector3.zero;
        if (IsHorizontalMovementEnabled)
        {
            Vector3 horizontalMovement = horizontalMovementController.CalculateHorizontalMovement();
            vectorToMove.x = horizontalMovement.x;
            vectorToMove.z = horizontalMovement.z;
        }
        if (isVerticalMovementEnabled)
        {
            vectorToMove.y = verticalMovementController.GetVerticalMovement();
        }
        characterController.Move(vectorToMove);

    }


    public void SetVerticalMovementEnabled(bool enabled)
    {
        isVerticalMovementEnabled = enabled;
    }

}

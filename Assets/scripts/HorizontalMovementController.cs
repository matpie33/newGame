using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovementController : MonoBehaviour
{
    private const float MOVEMENT_SPEED = 0.1f;
    [SerializeField]
    private float speed = 1f;
    float smoothVelocity;
    [SerializeField]
    private float turnSmoothTime = 0.1f;
    [SerializeField]
    private Transform cameraTransform;
    private VerticalMovementController gravityHandler;
    private Animator animator;
    private Vector3 currentMovementDirection;
    private float maxDelta = 0.1f;
    private bool respondToArrowKeys = true;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }


    public Vector3 CalculateHorizontalMovement()
    {

        Vector3 direction = CalculateDirectionToMove();
        bool isMovingBackward = IsMovingBackward();
        float targetAngle = CalculateTargetAngle(direction);
        Vector3 movementDirection = CalculateHorizontalMovementDirection(targetAngle);
        if (direction.magnitude > 0 && !isMovingBackward)
        {
            RotateCharacterTowardsAngle(targetAngle);
            animator.SetBool("run", true);

        }
        else if (isMovingBackward)
        {
            animator.SetBool("movingBackward", true);
            movementDirection *= 0.25f;
        }
        else
        {
            movementDirection = new Vector3(Mathf.MoveTowards(currentMovementDirection.x, 0, maxDelta), 0, Mathf.MoveTowards(currentMovementDirection.z, 0, maxDelta));
            animator.SetBool("run", false);
            animator.SetBool("movingBackward", false);
        }
        currentMovementDirection = movementDirection;
        movementDirection *= Time.deltaTime * MOVEMENT_SPEED;
        return movementDirection;
    }

    public void SetRespondingToArrowKeys(bool respondToArrowKeys)
    {
        this.respondToArrowKeys = respondToArrowKeys;
    }

    public Vector3 GetCurrentMovementDirection()
    {
        return currentMovementDirection;
    }

    private Vector3 AdjustVerticalSpeed(Vector3 horizontalMovementDirection)
    {
        float verticalSpeed = gravityHandler.CalculateVerticalSpeed();
        horizontalMovementDirection.y = verticalSpeed * MOVEMENT_SPEED;
        return horizontalMovementDirection;
    }

    private Vector3 CalculateHorizontalMovementDirection(float targetAngle)
    {
        Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        Vector3 horizontalMovement = moveDirection * speed;
        return horizontalMovement;
    }

    private bool IsMovingBackward()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        return vertical == -1 && horizontal == 0;
    }


    private void RotateCharacterTowardsAngle(float targetAngle)
    {
        float smoothedAngle = SmoothAngle(targetAngle);
        transform.rotation = Quaternion.Euler(0, smoothedAngle, 0);
    }

    private float CalculateTargetAngle(Vector3 direction)
    {
        return Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
    }

    private float SmoothAngle(float targetAngle)
    {
        return Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, turnSmoothTime);
    }

    private Vector3 CalculateDirectionToMove()
    {
        if (!respondToArrowKeys)
        {
            return Vector3.zero;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        return direction;
    }

}

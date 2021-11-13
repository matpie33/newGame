using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObjectCollisionDetection : MonoBehaviour
{
    private PickingUpObjectsController pickingUpObjectsHandler;

    private HorizontalMovementController horizontalMovementController;

    private AudioManager audioManager;

    private bool isFirstCollision = true;

    public void Start()
    {
        pickingUpObjectsHandler = FindObjectOfType<PickingUpObjectsController>();
        horizontalMovementController = FindObjectOfType<HorizontalMovementController>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!isFirstCollision)
        {
            audioManager.ToggleSound("boxCollisionSound", true);

        }
        else
        {
            isFirstCollision = false;
        }


        if (gameObject.Equals(pickingUpObjectsHandler.objectToPickup))
        {
            horizontalMovementController.MoveBack();
        }
    }


}

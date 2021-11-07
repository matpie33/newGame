using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObjectCollisionDetection : MonoBehaviour
{
    private PickingUpObjectsHandler pickingUpObjectsHandler;

    private HorizontalMovementController horizontalMovementController;

    public void Start()
    {
        pickingUpObjectsHandler = FindObjectOfType<PickingUpObjectsHandler>();
        horizontalMovementController = FindObjectOfType<HorizontalMovementController>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (gameObject.Equals(pickingUpObjectsHandler.objectToPickup))
        {
            horizontalMovementController.MoveBack();
        }
    }


}

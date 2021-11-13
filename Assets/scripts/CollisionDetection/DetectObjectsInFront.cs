using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjectsInFront : MonoBehaviour
{
    private LedgeDetectionState ledgeDetectionState;
    private PickingUpObjectsController pickingUpObjectsHandler;

    void Start()
    {
        ledgeDetectionState = GetComponentInParent<LedgeDetectionState>();
        pickingUpObjectsHandler = GetComponentInParent<PickingUpObjectsController>();
    }

    void OnTriggerEnter(Collider other)
    {
        ledgeDetectionState.IsThereWall = true;
    }

    void OnTriggerExit(Collider other)
    {
        GameManagement.instance.HidePickableObjectMarker();
        ledgeDetectionState.IsThereWall = false;
        pickingUpObjectsHandler.objectToPickup = null;
    }
}

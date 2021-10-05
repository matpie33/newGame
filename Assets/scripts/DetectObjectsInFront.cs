using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.States;

public class DetectObjectsInFront : MonoBehaviour
{
    private LedgeDetectionState ledgeDetectionState;
    private PickingUpObjectsHandler PickingUpObjectsHandler;

    void Start()
    {
        ledgeDetectionState = GetComponentInParent<LedgeDetectionState>();
        PickingUpObjectsHandler = GetComponentInParent<PickingUpObjectsHandler>();
    }

    void OnTriggerEnter(Collider other)
    {
        ledgeDetectionState.isThereWall = true;
        GameManagement.instance.HandleShowingPickableObjectMarker(other);

    }

    void OnTriggerExit(Collider other)
    {
        GameManagement.instance.HidePickableObjectMarker();
        ledgeDetectionState.isThereWall = false;
        PickingUpObjectsHandler.ObjectToPickup = null;
    }
}

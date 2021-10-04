using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.States;

public class DetectObjectsInFront : MonoBehaviour
{
    private LedgeDetectionState ledgeDetectionState;
    private DaleStateHandler daleStateHandler;

    void Start()
    {
        ledgeDetectionState = GetComponentInParent<LedgeDetectionState>();
        daleStateHandler = GetComponentInParent<DaleStateHandler>();
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
        daleStateHandler.ObjectToPickup = null;
    }
}

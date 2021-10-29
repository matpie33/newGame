﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.States;

public class DetectObjectsInFront : MonoBehaviour
{
    private LedgeDetectionState ledgeDetectionState;
    private PickingUpObjectsHandler pickingUpObjectsHandler;

    void Start()
    {
        ledgeDetectionState = GetComponentInParent<LedgeDetectionState>();
        pickingUpObjectsHandler = GetComponentInParent<PickingUpObjectsHandler>();
    }

    void OnTriggerEnter(Collider other)
    {
        ledgeDetectionState.IsThereWall = true;
        GameManagement.instance.HandleShowingPickableObjectMarker(other);

    }

    void OnTriggerExit(Collider other)
    {
        GameManagement.instance.HidePickableObjectMarker();
        ledgeDetectionState.IsThereWall = false;
        pickingUpObjectsHandler.ObjectToPickup = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFreeSpaceToClimb : MonoBehaviour
{

    private LedgeDetectionState ledgeDetectionState;

    void Start()
    {
        ledgeDetectionState = GetComponentInParent<LedgeDetectionState>();
    }

    void OnTriggerEnter(Collider other)
    {
        ledgeDetectionState.IsThereSpaceToClimb = false;

    }

    void OnTriggerExit(Collider other)
    {

        ledgeDetectionState.IsThereSpaceToClimb = true;
        ledgeDetectionState.LocationToTeleport = transform.position;

    }

}

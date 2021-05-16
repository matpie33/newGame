using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWall : MonoBehaviour
{
    private LedgeDetectionState ledgeDetectionState;
    public Vector3 contactPoint { get; set; }

    void Start()
    {
        ledgeDetectionState = GetComponentInParent<LedgeDetectionState>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("is wall");
        ledgeDetectionState.isThereWall = true;
        contactPoint = gameObject.transform.position;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("no wall");
        ledgeDetectionState.isThereWall = false;
    }
}

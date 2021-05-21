using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjectsInFront : MonoBehaviour
{
    private LedgeDetectionState ledgeDetectionState;
    public GameObject objectsMarker;

    public Vector3 contactPoint { get; set; }

    void Start()
    {
        ledgeDetectionState = GetComponentInParent<LedgeDetectionState>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("is wall");
        ledgeDetectionState.isThereWall = true;
        if (other.attachedRigidbody!= null && other.attachedRigidbody.mass <20)
        {
            objectsMarker.SetActive(true);
            Vector3 positionForMarker = other.transform.position;
            positionForMarker.y += other.bounds.size.y/2 + objectsMarker.GetComponent<MeshRenderer>().bounds.size.y/2;
            objectsMarker.transform.position = positionForMarker;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("no wall");
        objectsMarker.SetActive(false);
        ledgeDetectionState.isThereWall = false;
    }
}

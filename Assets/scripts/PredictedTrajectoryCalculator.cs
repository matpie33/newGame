using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedTrajectoryCalculator : MonoBehaviour
{

    [SerializeField]
    private GameObject destinationMarker;

    private PickingUpObjectsHandler pickingUpObjectsHandler;

    private float deltaTimeToCalculateTrajectory = 0.05f;

    private float maxTimeOfCalculation = 0.4f;

    public void Start()
    {
        pickingUpObjectsHandler = GetComponent<PickingUpObjectsHandler>();
    }

    public void SetEnabled(bool enabled)
    {
        this.enabled = enabled;
        destinationMarker.SetActive(enabled);
    }


    public void Update()
    {
        Rigidbody thrownObjectRB = pickingUpObjectsHandler.ObjectToPickup.GetComponent<Rigidbody>();
        Vector3 startingVelocity = pickingUpObjectsHandler.GetInitialSpeedForThrownObject();
        Vector3 startingPosition = thrownObjectRB.gameObject.transform.position;
        Vector3 destination = Vector3.zero;
        Vector3 newPoint = Vector3.zero;
        for (float t = 0; t < maxTimeOfCalculation; t += deltaTimeToCalculateTrajectory)
        {
            newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            destination = newPoint;
        }
        destinationMarker.transform.position = destination;
    }

}

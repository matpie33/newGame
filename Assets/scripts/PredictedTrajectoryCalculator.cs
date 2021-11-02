using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedTrajectoryCalculator : MonoBehaviour
{

    private GameObject destinationMarker;

    private PickingUpObjectsHandler pickingUpObjectsHandler;

    private float deltaTimeToCalculateTrajectory = 0.01f;

    private float maxTimeOfCalculation = 0.4f;

    [SerializeField]
    private LayerMask collidableLayers;

    [SerializeField]
    private float sphereRadiusToCheckForObstacles = 1;

    public void Start()
    {
        pickingUpObjectsHandler = GetComponent<PickingUpObjectsHandler>();
        enabled = false;
    }

    public void SetEnabled(bool enabled)
    {
        this.enabled = enabled;
        if (enabled)
        {
            destinationMarker = Instantiate(pickingUpObjectsHandler.ObjectToPickup);
            destinationMarker.GetComponent<Collider>().isTrigger = true;
            destinationMarker.transform.localScale = Vector3.one;
        }
        else {
            Destroy(destinationMarker);
        }
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
            Collider[] colliders = Physics.OverlapSphere(newPoint, sphereRadiusToCheckForObstacles, collidableLayers);
            if (colliders.Length > 0 && !colliders[0].gameObject.Equals(destinationMarker) && !colliders[0].gameObject.Equals(pickingUpObjectsHandler.ObjectToPickup))
            {
                break;
            }
        }
        destinationMarker.transform.position = destination;
        destinationMarker.transform.rotation = Quaternion.identity;
    }

}

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
    private float sphereRadiusToCheckForObstacles = 0.5f;

    [SerializeField]
    private Material materialToApply;

    private Dictionary<GameObject, Material> objectsMarkedAsThrowingDestination = new Dictionary<GameObject, Material>();

    [SerializeField]
    private Material materialForDestinationMarker;


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
            destinationMarker.GetComponent<Rigidbody>().useGravity = false;
            destinationMarker.transform.localScale = pickingUpObjectsHandler.ObjectToPickup.transform.lossyScale;
            destinationMarker.GetComponentInChildren<Renderer>().material.color = Color.red;
        }
        else
        {
            Destroy(destinationMarker);
        }
    }


    private void OnDisable()
    {
        ClearObjectsMarkedAsDestinations();
    }

    public void Update()
    {
        Rigidbody thrownObjectRB = pickingUpObjectsHandler.ObjectToPickup.GetComponent<Rigidbody>();
        Vector3 startingVelocity = pickingUpObjectsHandler.GetInitialSpeedForThrownObject();
        Vector3 startingPosition = thrownObjectRB.gameObject.transform.position;
        Vector3 destination = Vector3.zero;
        Vector3 newPoint = startingPosition;

        for (float t = 0; t < 0.4; t += deltaTimeToCalculateTrajectory)
        {
            newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            destination = newPoint;
            Collider[] colliders = Physics.OverlapSphere(newPoint, sphereRadiusToCheckForObstacles);
            if (colliders.Length > 0 && !colliders[0].gameObject.Equals(destinationMarker) && !colliders[0].gameObject.Equals(pickingUpObjectsHandler.ObjectToPickup))
            {
                if (objectsMarkedAsThrowingDestination.ContainsKey(colliders[0].gameObject))
                {
                    destinationMarker.transform.position = destination;
                    return;
                }
                ClearObjectsMarkedAsDestinations();
                objectsMarkedAsThrowingDestination.Add(colliders[0].gameObject, colliders[0].gameObject.GetComponentInChildren<Renderer>().material);
                colliders[0].gameObject.GetComponentInChildren<Renderer>().material = materialToApply;
                destinationMarker.transform.position = destination;
                return;
            }
        }
        destinationMarker.transform.position = destination;
        if (objectsMarkedAsThrowingDestination.Count > 0)
        {
            ClearObjectsMarkedAsDestinations();
            destinationMarker.SetActive(true);
        }
        destinationMarker.transform.rotation = Quaternion.identity;
    }

    private void ClearObjectsMarkedAsDestinations()
    {
        foreach (KeyValuePair<GameObject, Material> entry in objectsMarkedAsThrowingDestination)
        {
            entry.Key.GetComponentInChildren<Renderer>().material = entry.Value;
        }
        objectsMarkedAsThrowingDestination.Clear();
    }
}

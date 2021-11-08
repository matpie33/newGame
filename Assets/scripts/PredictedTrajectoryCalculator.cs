using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedTrajectoryCalculator : MonoBehaviour
{

    private GameObject destinationMarker;

    private PickingUpObjectsHandler pickingUpObjectsHandler;

    private float deltaTimeToCalculateTrajectory = 0.01f;


    [SerializeField]
    private float sphereRadiusToCheckForObstacles = 0.5f;

    [SerializeField]
    private Material materialToApply;

    private Dictionary<GameObject, Material> objectsMarkedAsThrowingDestination = new Dictionary<GameObject, Material>();




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
            destinationMarker = Instantiate(pickingUpObjectsHandler.objectToPickup);
            destinationMarker.GetComponent<Collider>().isTrigger = true;
            destinationMarker.GetComponent<Rigidbody>().useGravity = false;
            destinationMarker.transform.localScale = pickingUpObjectsHandler.objectToPickup.transform.lossyScale;
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
        Rigidbody thrownObjectRB = pickingUpObjectsHandler.objectToPickup.GetComponent<Rigidbody>();
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
            Collider closestCollider = FindClosestCollider(colliders);
            if (closestCollider!=null)
            {
                Vector3 sumOfBounds = Vector3.Scale(closestCollider.gameObject.GetComponentInChildren<Renderer>().bounds.size, new Vector3(1, 0, 1)*0.5f) +
                     Vector3.Scale(
                     pickingUpObjectsHandler.gameObject.GetComponentInChildren<Renderer>().bounds.size, new Vector3(1, 0, 1) * 0.5f);
                float distanceBetweenObjects = Vector3.Distance(closestCollider.gameObject.transform.position, pickingUpObjectsHandler.transform.position) - sumOfBounds.magnitude;
                if (distanceBetweenObjects < 0.3f)
                {
                    ClearObjectsMarkedAsDestinations();
                    destinationMarker.SetActive(false);
                    return;
                }
                ClearObjectsMarkedAsDestinations();
                destinationMarker.SetActive(true);
                objectsMarkedAsThrowingDestination.Add(closestCollider.gameObject, closestCollider.gameObject.GetComponentInChildren<Renderer>().material);
                closestCollider.gameObject.GetComponentInChildren<Renderer>().material = materialToApply;
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

    private Collider FindClosestCollider(Collider[] colliders)
    {
        float distanceToPickedObject = Mathf.Infinity;
        Collider closestCollider = null;

        foreach (Collider collider in colliders)
        {
            GameObject collidingObject = collider.gameObject;
            if (collidingObject.Equals(destinationMarker) || collidingObject.Equals(pickingUpObjectsHandler.objectToPickup) || collider.gameObject.transform.IsChildOf(gameObject.transform))
            {
                continue;
            }
            float distanceFromColliderToPickedObject = Vector3.Distance(collider.gameObject.transform.position, pickingUpObjectsHandler.objectToPickup.transform.position);
            if (distanceFromColliderToPickedObject < distanceToPickedObject)
            {
                distanceToPickedObject = distanceFromColliderToPickedObject;
                closestCollider = collider;
            }
        }
        
        return closestCollider;
    }

    private bool AreAllCollidersChildrenOfDale(Collider[] colliders)
    {

        foreach (Collider c in colliders)
        {
            if (!c.gameObject.transform.IsChildOf(gameObject.transform) && !c.gameObject.Equals(pickingUpObjectsHandler.objectToPickup))
            {

                return false;
            }
        }
        return true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePredictedTrajectory : MonoBehaviour
{

    public GameObject pickableObjectMarker;

    public void drawDestination(Collider collider, int force)
    {
        GameObject pickedObject = collider.gameObject;
        Rigidbody rigidBody = pickedObject.GetComponent<Rigidbody>();
        float mass = rigidBody.mass;
        double result = ((force / (int)mass) ^ 2) * 0.5 / (-9.81);
        Vector3 oldPosition = pickedObject.transform.position;
        Vector3 newPosition = oldPosition + new Vector3((int)result, 0, (int)result);
        pickableObjectMarker.transform.position = newPosition;
        pickableObjectMarker.SetActive(true);
    }
}

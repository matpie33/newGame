using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPickableObjects : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        GameManagement.instance.HandleShowingPickableObjectMarker(other);
        GameManagement.instance.SetObjectToPickup(other.gameObject);
    }


    public void OnTriggerExit(Collider other)
    {
        GameManagement.instance.HidePickableObjectMarker();
    }

}

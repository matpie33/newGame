using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPickableObjects : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        GameManagement.instance.SetObjectToPickup(other.gameObject);
        GameManagement.instance.HandleShowingPickableObjectMarker(other);
    }


    public void OnTriggerExit(Collider other)
    {
        GameManagement.instance.HidePickableObjectMarker();
    }

}

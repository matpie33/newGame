using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPickableObjects : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        bool isPickable = GameManagement.instance.HandleShowingPickableObjectMarker(other);
        if (isPickable)
        {
            GameManagement.instance.SetObjectToPickup(other.gameObject);
        }
    }


    public void OnTriggerExit(Collider other)
    {
        GameManagement.instance.HandleHidingPickableObjectMarker(other.gameObject);


    }

}

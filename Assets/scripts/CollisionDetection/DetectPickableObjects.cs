using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPickableObjects : MonoBehaviour
{

    private ISet<GameObject> objectsWithWhichICollide = new HashSet<GameObject>();
    private PickingUpObjectsController pickingUpObjectsController;
    private PickableObjectsMarkerManager pickableObjectsMarkerManager;

    public void Start()
    {
        pickingUpObjectsController = FindObjectOfType<PickingUpObjectsController>();
        pickableObjectsMarkerManager = FindObjectOfType<PickableObjectsMarkerManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        bool isPickable = pickableObjectsMarkerManager.HandleShowingPickableObjectMarker(other);
        if (isPickable)
        {
            objectsWithWhichICollide.Add(other.gameObject);
            pickingUpObjectsController.objectToPickup = other.gameObject;
        }
    }


    public void OnTriggerExit(Collider other)
    {
        objectsWithWhichICollide.Remove(other.gameObject);
        if (objectsWithWhichICollide.Count == 0)
        {
            pickableObjectsMarkerManager.HandleHidingPickableObjectMarker();
            pickingUpObjectsController.objectToPickup = null;
        }



    }

}

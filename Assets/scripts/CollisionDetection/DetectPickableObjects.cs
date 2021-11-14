using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPickableObjects : MonoBehaviour
{

    private ISet<GameObject> objectsWithWhichICollide = new HashSet<GameObject>();

    public void OnTriggerEnter(Collider other)
    {
        bool isPickable = GameManagement.instance.HandleShowingPickableObjectMarker(other);
        if (isPickable)
        {
            objectsWithWhichICollide.Add(other.gameObject);
            GameManagement.instance.SetObjectToPickup(other.gameObject);
        }
    }


    public void OnTriggerExit(Collider other)
    {
        objectsWithWhichICollide.Remove(other.gameObject);
        if (objectsWithWhichICollide.Count == 0)
        {
            GameManagement.instance.HandleHidingPickableObjectMarker();
            GameManagement.instance.SetObjectToPickup(null);
        }
        


    }

}

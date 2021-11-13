using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFreeSpaceToClimb : MonoBehaviour
{

    private LedgeDetectionState ledgeDetectionState;
    private ISet<GameObject> objectsWithWhichDaleCollides = new HashSet<GameObject>();

    void Start()
    {
        ledgeDetectionState = GetComponentInParent<LedgeDetectionState>();
    }

    void OnTriggerEnter(Collider other)
    {
        ledgeDetectionState.IsThereSpaceToClimb = false;
        objectsWithWhichDaleCollides.Add(other.gameObject);


    }

    void OnTriggerExit(Collider other)
    {
        objectsWithWhichDaleCollides.Remove(other.gameObject);
        if (objectsWithWhichDaleCollides.Count == 0)
        {
            ledgeDetectionState.IsThereSpaceToClimb = true;
        }



    }

}

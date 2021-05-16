using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndThrow : MonoBehaviour
{

    public void Throw()
    {
        GameManagement gameManagement = FindObjectOfType<GameManagement>();
        gameManagement.Throw();
    }

    public void PickupObject()
    {
        GameManagement gameManagement = FindObjectOfType<GameManagement>();
        Collider pickedObject = gameManagement.PickupObject();
        CalculatePredictedTrajectory calculatePredictedTrajectory = FindObjectOfType<CalculatePredictedTrajectory>();
        calculatePredictedTrajectory.drawDestination(pickedObject, GameManagement.force);
    }

    public void SetIdle()
    {
        GameManagement gameManagement = FindObjectOfType<GameManagement>();
        gameManagement.SetIdle();
    }

}

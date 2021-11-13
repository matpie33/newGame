using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ReleasingObjectsState : State
{
    private bool isReleasingSuccessful;

    public State DuringState(DaleStateHandler daleStateHandler)
    {
        if (daleStateHandler.keyboardController.IsPickupOrReleaseObjectsKeyPressed)
        {
            return this;
        }
        else if (isReleasingSuccessful)
        {
            isReleasingSuccessful = false;
            return daleStateHandler.walkingState;
        }
        else
        {
            return daleStateHandler.holdingObjectState;
        }

    }

    public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
    {

        daleStateHandler.predictedTrajectoryCalculator.SetEnabled(false);
        isReleasingSuccessful = daleStateHandler.pickingUpObjectsHandler.PutObjectInFront();


    }


}
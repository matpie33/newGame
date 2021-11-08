﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ReleasingObjectsState : State
{

    public State DuringState(DaleStateHandler daleStateHandler)
    {
        if (!daleStateHandler.keyboardController.IsPickupOrReleaseObjectsKeyPressed)
        {
            return daleStateHandler.walkingState;
        }
        else
        {
            return this;
        }

    }

    public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
    {

        daleStateHandler.predictedTrajectoryCalculator.SetEnabled(false);
        daleStateHandler.pickingUpObjectsHandler.PutObjectInFront();


    }


}
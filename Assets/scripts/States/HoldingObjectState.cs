using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HoldingObjectState : State
{

    public State DuringState(DaleStateHandler daleStateHandler)
    {
        if (daleStateHandler.keyboardController.IsPickupOrReleaseObjectsKeyPressed)
        {
            return daleStateHandler.releasingObjectsState;
        }
        else if (daleStateHandler.keyboardController.IsThrowingKeyPressed)
        {
            return daleStateHandler.throwingObjectsState;
        }
        else
        {
            return this;
        }
    }

    public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
    {
        daleStateHandler.pickingUpObjectsHandler.PickupObject();
        daleStateHandler.predictedTrajectoryCalculator.SetEnabled(true);

    }




}

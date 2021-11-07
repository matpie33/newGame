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
        else if (daleStateHandler.keyboardController.IsThrowingOrPuttingObjectKeyPressed)
        {
            return daleStateHandler.throwingObjectsState;
        }
        else if (daleStateHandler.keyboardController.IsSwitchBetweenPuttingAndThrowingObjectsKeyPressed)
        {
            daleStateHandler.keyboardController.SwitchBetweenPuttingAndThrowingObjectsConsumed();
            return daleStateHandler.puttingObjectsState;
        }
        else
        {
            return this;
        }
    }

    public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
    {
        if (!previousState.Equals(daleStateHandler.puttingObjectsState))
        {
            daleStateHandler.pickingUpObjectsHandler.PickupObject();
            daleStateHandler.predictedTrajectoryCalculator.SetEnabled(true);
        }

    }




}

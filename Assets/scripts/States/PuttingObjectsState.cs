using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PuttingObjectsState : State
{

    public State DuringState(DaleStateHandler daleStateHandler)
    {
        if (daleStateHandler.keyboardController.IsSwitchBetweenPuttingAndThrowingObjectsKeyPressed)
        {
            daleStateHandler.keyboardController.SwitchBetweenPuttingAndThrowingObjectsConsumed();
            return daleStateHandler.holdingObjectState;
        }
        else if (daleStateHandler.keyboardController.IsThrowingOrPuttingObjectKeyPressed)
        {
            daleStateHandler.pickingUpObjectsHandler.PutObjectInFront();
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

    }




}

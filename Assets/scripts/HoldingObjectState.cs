using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts.States
{
    class HoldingObjectState : MonoBehaviour, State
    {

        public State DuringState(DaleStateHandler daleStateHandler)
        {
            if (daleStateHandler.keyboardController.IsPickupOrReleaseObjectsKeyPressed)
            {
                return daleStateHandler.releasingObjectsState;
            }
            else if (daleStateHandler.keyboardController.IsThrowingObjectKeyPressed)
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
            daleStateHandler.PickingUpObjectsHandler.PickupObject();

        }




    }
}

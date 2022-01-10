using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class PickingUpObjectsState : State
{
    private Animator animator;

    public State DuringState(DaleStateHandler daleStateHandler)
    {
        if (!daleStateHandler.pickingUpObjectsHandler.GetIsPickingUpObject())
        {
            return this;
        }
        else
        {
            return daleStateHandler.holdingObjectState;
        }
    }

    public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
    {

        daleStateHandler.pickableObjectsMarkerManager.HandleHidingPickableObjectMarker();
        animator = daleStateHandler.animator;
        animator.SetBool("pickupObjects", true);
        daleStateHandler.horizontalMovementController.MovementEnabled = false;
        daleStateHandler.pickingUpObjectsHandler.CalculatePlayerPositionForPickingUpObject();
    }




}

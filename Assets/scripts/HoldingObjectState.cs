using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts.States
{
    class HoldingObjectState : MonoBehaviour, State
    {

        public State DuringState(DaleStateHandler daleStateHandler)
        {
            if (daleStateHandler.keyboardController.isPickupOrReleaseObjectsKeyPressed)
            {
                return daleStateHandler.releasingObjectsState;
            }
            else
            {
                return this;
            }
        }

        public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
        {
            GameObject objectToPickup = daleStateHandler.ObjectToPickup;
            daleStateHandler.ObjectToPickup.GetComponent<Rigidbody>().isKinematic = true;
            daleStateHandler.ObjectsInFrontDetectingCollider.enabled = false;
            objectToPickup.transform.parent = daleStateHandler.ParentPositionObject.transform;
            daleStateHandler.animator.SetBool("pickupObjects", false);
            daleStateHandler.RigsHandler.EnablePickupObjectRig();

        }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.States
{
    class PickingUpObjectsState : MonoBehaviour, State
    {


        public State DuringState(DaleStateHandler daleStateHandler)
        {
            if (daleStateHandler.keyboardController.isPickupOrReleaseObjectsKeyPressed)
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
            Debug.Log("picking up");
            daleStateHandler.animator.SetBool("pickupObjects", true);
            daleStateHandler.ObjectToPickup.transform.parent = GameObject.FindGameObjectWithTag("Picking").transform;
            daleStateHandler.ObjectToPickup.GetComponent<Rigidbody>().isKinematic = true;




        }


    }
}

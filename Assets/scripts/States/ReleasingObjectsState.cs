using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts.States
{
    class ReleasingObjectsState : MonoBehaviour, State
    {


        public State DuringState(DaleStateHandler daleStateHandler)
        {
            if (!daleStateHandler.keyboardController.isPickupOrReleaseObjectsKeyPressed)
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
            Debug.Log("released");
            daleStateHandler.animator.SetBool("pickupObjects", false);
            daleStateHandler.ObjectToPickup.transform.parent = null;
            daleStateHandler.ObjectToPickup.GetComponent<Rigidbody>().isKinematic = false;



        }


    }
}

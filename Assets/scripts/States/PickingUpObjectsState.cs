﻿using System;
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
            if (!daleStateHandler.GetIsPickingUpObject())
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
            daleStateHandler.animator.SetBool("pickupObjects", true);
            GameManagement.instance.HidePickableObjectMarker();




        }



    }
}
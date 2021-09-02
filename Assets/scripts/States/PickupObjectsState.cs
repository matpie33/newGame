using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts.States
{
    class PickupObjectsState : State
    {

        public State DuringState(DaleStateHandler daleStateHandler)
        {
            return daleStateHandler.walkingState;
        }

        public void OnTransition(State previousState, DaleStateHandler daleStateHandler)
        {
            daleStateHandler.animator.SetBool("pickupObjects", true);
        }
    }
}

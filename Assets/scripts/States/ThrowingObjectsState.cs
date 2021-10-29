using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class ThrowingObjectsState : MonoBehaviour, State
{


    public State DuringState(DaleStateHandler daleStateHandler)
    {
        if (!daleStateHandler.keyboardController.IsThrowingObjectKeyPressed)
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

        daleStateHandler.animator.SetBool("throwObjects", true);

    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class PickingUpObjectsState : MonoBehaviour, State
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
        GameManagement.instance.HidePickableObjectMarker();
        animator = daleStateHandler.animator;
        AnimatePickingUp();
    }

    public void AnimatePickingUp()
    {
        animator.SetBool("pickupObjects", true);
    }



}

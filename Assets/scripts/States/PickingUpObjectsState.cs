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
        private Animator animator;

        public State DuringState(DaleStateHandler daleStateHandler)
        {
            if (!daleStateHandler.PickingUpObjectsHandler.GetIsPickingUpObject())
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
            GameObject dale = daleStateHandler.gameObject;
            GameObject objectToPickup = daleStateHandler.PickingUpObjectsHandler.ObjectToPickup;
            Vector3 sizeOfPickedObject = objectToPickup.GetComponent<Renderer>().bounds.size;
            Vector3 daleForward = dale.transform.forward;
            Vector3 directionTowardDale = -daleForward;
            Vector3 targetPosition;
            if (directionTowardDale.x < directionTowardDale.z)
            {
                targetPosition = objectToPickup.transform.position + new Vector3(0, 0, sizeOfPickedObject.z / 2);
            }
            else
            {
                targetPosition = objectToPickup.transform.position + new Vector3(sizeOfPickedObject.x / 2, 0, 0);
            }

            //MovingToTarget movingToTarget = daleStateHandler.movingToTarget;
            animator = daleStateHandler.Animator;
            animatePickingUp();
            //movingToTarget.setTargetPosition(targetPosition);
            //movingToTarget.callback = animatePickingUp;




        }

        public void animatePickingUp()
        {
            animator.SetBool("pickupObjects", true);
        }



    }
}

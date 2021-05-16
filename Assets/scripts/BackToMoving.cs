using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMoving : StateMachineBehaviour
{

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        LedgeDetectionState ledgeDetectionState = FindObjectOfType<LedgeDetectionState>();

        ThirdPersonMovement thirdPersonMovement = FindObjectOfType<ThirdPersonMovement>();
        GravityHandler gravityHandler = FindObjectOfType<GravityHandler>();
        CharacterController characterController = FindObjectOfType<CharacterController>();
        DetectWall detectLedge = FindObjectOfType<DetectWall>();
        CurrentDaleState currentDaleState = FindObjectOfType<CurrentDaleState>();
        currentDaleState.UpdateState(DaleStates.WALKING);
        characterController.transform.position = ledgeDetectionState.locationToTeleport;
        thirdPersonMovement.enabled = true;
    }




    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingAnimationFinished : StateMachineBehaviour
{

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<DaleStateHandler>().grabbingLedgeState.OnClimbingAnimationFinished();

    }
}

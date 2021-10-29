using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareToJumpFinished : StateMachineBehaviour
{


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("state exit");
        FindObjectOfType<VerticalMovementController>().JumpToAir();
    }

}

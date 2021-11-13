using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBothHandsAnimationStartBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<DaleRigsController>().DisablePickupObjectRig();

    }
}

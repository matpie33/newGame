using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaleDieAnimationFinished : StateMachineBehaviour
{

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManagement.instance.ResetDaleToBossStage();
    }

}

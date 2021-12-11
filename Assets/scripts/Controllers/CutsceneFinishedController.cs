using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneFinishedController : MonoBehaviour
{

    [SerializeField]
    private PlayableDirector playableDirector;

    private HorizontalMovementController horizontalMovementController;


    public void OnEnable()
    {
        playableDirector.stopped += OnPlayableDirectorStopped;
        playableDirector = GetComponent<PlayableDirector>();
        horizontalMovementController = FindObjectOfType<HorizontalMovementController>();
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (playableDirector = aDirector)
        {
            FindObjectOfType<BossAttackController>().enabled = true;
            horizontalMovementController.MovementEnabled = true;

        }
    }
}

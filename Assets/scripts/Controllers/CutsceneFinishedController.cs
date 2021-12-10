using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneFinishedController : MonoBehaviour
{

    [SerializeField]
    private PlayableDirector playableDirector;

    private DaleMovementController daleMovementController;


    public void OnEnable()
    {
        playableDirector.stopped += OnPlayableDirectorStopped;
        playableDirector = GetComponent<PlayableDirector>();
        daleMovementController = FindObjectOfType<DaleMovementController>();
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (playableDirector = aDirector)
        {
            FindObjectOfType<BossAttackController>().enabled = true;
            daleMovementController.enabled = true;

        }
    }
}

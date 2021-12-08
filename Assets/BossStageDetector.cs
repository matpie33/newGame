using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BossStageDetector : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField]
    private GameObject boss;

    [SerializeField]
    private GameObject bossUI;

    [SerializeField]
    private PlayableDirector playableDirector;

    private DaleMovementController movementController;

    private GameObject dale;

    private bool played;

    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        movementController = FindObjectOfType<DaleMovementController>();
        dale = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!played && other.gameObject.tag.Equals(TagsManager.PLAYER))
        {
            audioManager.ToggleSound("BossMusic", true);
            audioManager.ToggleSound("stageMusic", false);
            boss.SetActive(true);
            bossUI.SetActive(true);
            playableDirector.Play();
            played = true;
            movementController.enabled = false;
            SavingAndLoading.Save(dale);


        }
    }


}

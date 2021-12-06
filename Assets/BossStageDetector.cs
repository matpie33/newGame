using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageDetector : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField]
    private GameObject boss;

    [SerializeField]
    private GameObject bossUI;
    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(TagsManager.PLAYER))
        {
            audioManager.ToggleSound("BossMusic", true);
            audioManager.ToggleSound("stageMusic", false);
            boss.SetActive(true);
            bossUI.SetActive(true);
        }
    }

}

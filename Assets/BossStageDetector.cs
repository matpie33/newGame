using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageDetector : MonoBehaviour
{
    private AudioManager audioManager;
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
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    public void ToggleSound(string audioName, bool shouldTurnOn)
    {
        int numberOfChildren = gameObject.transform.childCount;
        for (int i = 0; i < numberOfChildren; i++)
        {
            Transform audioSound = gameObject.transform.GetChild(i);
            if (audioSound.gameObject.name.Equals(audioName))
            {
                AudioSource audioSource = audioSound.gameObject.GetComponent<AudioSource>();
                if (shouldTurnOn && !audioSource.isPlaying)
                {
                    audioSource.Play();

                }
                else if (!shouldTurnOn)
                {
                    audioSource.Stop();
                }

            }

        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("instructions");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

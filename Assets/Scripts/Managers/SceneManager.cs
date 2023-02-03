using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("..");
    }

    public void Tutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialScene");
    }

    public void Credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditsScene");
    }

    public void Options()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OptionScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void X()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}

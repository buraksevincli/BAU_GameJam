using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static SceneManager _instance;

    public static SceneManager Instance => _instance;
    
    [SerializeField] private GameObject _volumeBar;
    [SerializeField] private GameObject _volumeBarActive;
    [SerializeField] private GameObject _volumeBarDeactive;

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialScene");
    }

    public void Credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditsScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Home()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void VolumeBarActive()
    {
        _volumeBar.SetActive(true);
        _volumeBarActive.SetActive(false);
        _volumeBarDeactive.SetActive(true);
    }

    public void VolumeBarDeactive()
    {
        _volumeBar.SetActive(false);
        _volumeBarActive.SetActive(true);
        _volumeBarDeactive.SetActive(false);
    }
}

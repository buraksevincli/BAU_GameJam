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
    [SerializeField] private GameObject _eminMisin;

    string currentScene = "HomeScene";


    private void Awake()
    {
        currentScene = PlayerPrefs.GetString("currentScene", currentScene);
        
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }

    public void Credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditsScene");
    }

    public void Exit()
    {
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("currentScene", currentScene);
        PlayerPrefs.Save();
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

    public void ResetButon()
    {
        _eminMisin.SetActive(true);
        
    }

    public void Evet()
    {
        currentScene = "HomeScene";
        PlayerPrefs.SetString("currentScene", currentScene);
        PlayerPrefs.Save();
    }

    public void Hayır()
    {
        _eminMisin.SetActive(false);
    }
}

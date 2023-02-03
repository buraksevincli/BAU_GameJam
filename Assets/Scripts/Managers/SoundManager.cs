using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance => _instance;

    public AudioClip[] audio;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad((this.gameObject));
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    public void SetAudio(float value)
    {
        foreach (AudioClip music in audio)
        {
            
        }
        AudioListener.volume = value;
    }
}
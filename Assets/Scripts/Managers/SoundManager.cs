using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance => _instance;

    public AudioClip[] audio;

    AudioSource audioSourceMusic;

    private void Awake()
    {
        audioSourceMusic = GetComponent<AudioSource>();
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

    private void Start()
    {
        audioSourceMusic.mute = false;
    }
    private void Update()
    {
        if (PlayerController.bossEnter)
        {
            audioSourceMusic.mute = true;
        }
        else
        {
            audioSourceMusic.mute = false;
        }
    }

    public void SetAudio(float value)
    {
        AudioListener.volume = value;
    }
}
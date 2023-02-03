using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;
    
    public static EventManager Instance => _instance;

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
}
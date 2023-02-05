using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Tutorial"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1Desing");
        }

        if (col.gameObject.CompareTag("Level1"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level2Desing");
        }
    }
}

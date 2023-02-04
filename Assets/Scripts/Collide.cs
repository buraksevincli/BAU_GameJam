using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Tutorial"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.SetActive(false);
            _explosion.SetActive(true);
        }
    }
}

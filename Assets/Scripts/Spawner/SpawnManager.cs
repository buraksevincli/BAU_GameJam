using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _root;
    bool doOnce;
    private void Start()
    {
        doOnce = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& doOnce)
        {
            doOnce = false;
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(_root, transform.position, Quaternion.identity);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantActivator : MonoBehaviour
{
    [SerializeField] private GameObject _plant;
    [SerializeField] private GameObject _spawnPoint1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Slash") ||
            col.gameObject.CompareTag("Bullet"))
        {
            Instantiate(_plant, _spawnPoint1.transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BulletSpawner_R : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private GameObject instantiatedBullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Invoke(nameof(Spawn),0.1f);
        }
    }

    private void Spawn()
    {
        instantiatedBullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        Destroy(instantiatedBullet,5f);
    }
}

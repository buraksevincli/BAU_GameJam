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

    bool canSpawn = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            StartCoroutine(SpawnBullet());
        }
    }
    IEnumerator SpawnBullet()
    {
        if (canSpawn)
        {
            canSpawn = false;
            yield return new WaitForSeconds(0.1f);
            instantiatedBullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            Destroy(instantiatedBullet, 5f);
            yield return new WaitForSeconds(0.4f);
            canSpawn = true;
        }
    }

}

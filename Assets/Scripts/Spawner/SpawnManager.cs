using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject square;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 5f, 1f);
    }

    void Spawn()
    {
        Instantiate(square, transform.position, Quaternion.identity);

    }


}

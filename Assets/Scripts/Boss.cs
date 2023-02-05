using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static float bossHealth = 1f;

    // Start is called before the first frame update
    void Start()
    {
        bossHealth = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bossHealth -= 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

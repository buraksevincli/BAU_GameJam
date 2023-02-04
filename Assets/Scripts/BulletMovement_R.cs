using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement_R : MonoBehaviour
{
    [SerializeField] float speed;


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed = 0;
        }
        else
        {
            speed = 0;
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}

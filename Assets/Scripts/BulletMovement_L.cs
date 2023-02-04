using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement_L : MonoBehaviour
{
    [SerializeField] float speed;


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            speed = 0;
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            speed = 0;
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}

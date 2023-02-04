using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement_L : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject explosion;
    GameObject instantiatedExplosion;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            speed = 0;
            instantiatedExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        else
        {
            speed = 0;
            instantiatedExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement_L : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject bulletHitGround;

    [SerializeField] GameObject popEffect;
    GameObject instantiatedPop;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            speed = 0;
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Bubble"))
        {
            instantiatedPop = Instantiate(popEffect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(instantiatedPop, 0.3f);
        }
        else
        {
            speed = 0;
            Instantiate(bulletHitGround, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}

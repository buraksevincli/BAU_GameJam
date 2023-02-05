using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPlantHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float bulletDamage;
    [SerializeField] float meleeDamage;

    float scaleX;
    float scaleY;

    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= bulletDamage;
        }
        else if (collision.gameObject.CompareTag("Slash"))
        {
            health -= meleeDamage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            scaleX -= 5f * Time.deltaTime;
            scaleY -= 5f * Time.deltaTime;
            scaleX = Mathf.Clamp(scaleX, 0, 1);
            scaleY = Mathf.Clamp(scaleY, 0, 1);

            transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
            Destroy(gameObject, 0.5f);
        }
    }
}

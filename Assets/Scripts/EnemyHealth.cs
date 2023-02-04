using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float bulletDamage;
    [SerializeField] float meleeDamage;

    float scaleX;
    float scaleY;
    float scaleZ;

    Animator _anim;
    CircleCollider2D _circleCol;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _circleCol = GetComponent<CircleCollider2D>();

        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;

        StartCoroutine(AnimOrder());
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
        Debug.Log(health);
        if(health <= 0)
        {
            scaleX -= 5f * Time.deltaTime;
            scaleY -= 5f * Time.deltaTime;
            scaleZ -= 5f * Time.deltaTime;
            scaleX = Mathf.Clamp(scaleX, 0, 1);
            scaleY = Mathf.Clamp(scaleY, 0, 1);
            scaleZ = Mathf.Clamp(scaleZ, 0, 1);

            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            Destroy(gameObject, 0.5f);
        }

    }

    IEnumerator AnimOrder()
    {
        _anim.SetBool("Attack", false);
        _anim.SetBool("Idle", true);
        yield return new WaitForSeconds(3f);
        _anim.SetBool("Idle", false);
        _anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.2f);
        _circleCol.enabled = true;
        yield return new WaitForSeconds(0.8f);
        _circleCol.enabled = false;
        StartCoroutine(AnimOrder());
    }



}

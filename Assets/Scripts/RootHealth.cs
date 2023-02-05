using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float bulletDamage;
    [SerializeField] float meleeDamage;

    float scaleX;
    float scaleY;

    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();

        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;

        StartCoroutine(AnimOrder());
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(SoundManager.Instance.audio[5],gameObject.transform.position);
            health -= bulletDamage;
        }
        else if (collision.gameObject.CompareTag("Slash"))
        {
            AudioSource.PlayClipAtPoint(SoundManager.Instance.audio[3],gameObject.transform.position);
            health -= meleeDamage;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            scaleX -= 5f * Time.deltaTime;
            scaleY -= 5f * Time.deltaTime;
            scaleX = Mathf.Clamp(scaleX, 0, 1);
            scaleY = Mathf.Clamp(scaleY, 0, 1);

            transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
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
        yield return new WaitForSeconds(1f);
        StartCoroutine(AnimOrder());
    }



}

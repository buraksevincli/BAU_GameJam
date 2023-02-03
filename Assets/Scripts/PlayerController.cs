using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    public float jumpForce;
    int moveDirection;
    bool jump = false;

    bool grounded = true;

    Rigidbody2D _rb2d;
    Animator _anim;
    SpriteRenderer _spriteR;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spriteR = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = new Vector2(runningSpeed * moveDirection, _rb2d.velocity.y);

        if (jump)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, jumpForce);
            jump = false;
        }
    }

    void Update()
    {
        Debug.Log(grounded);
        if (grounded)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1;
                _spriteR.flipX = true;
                _anim.SetBool("Idle", false);
                _anim.SetBool("Run", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1;
                _spriteR.flipX = false;
                _anim.SetBool("Idle", false);
                _anim.SetBool("Run", true);
            }
            else
            {
                moveDirection = 0;
                _anim.SetBool("Run", false);
                _anim.SetBool("Idle", true);
            }
        }
        else
        {

        }

        if (grounded && Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            grounded = false;
        }


    }
}

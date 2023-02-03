using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float _currentSpeed;
    public float jumpForce;
    int moveDirection;

    bool jump = false;
    bool slide = false;
    bool grounded = true;
    bool shoot = false;
    bool canShoot = true;
    bool melee = false;
    bool canMelee = true;

    Rigidbody2D _rb2d;
    Animator _anim;
    SpriteRenderer _spriteR;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spriteR = GetComponent<SpriteRenderer>();

        _currentSpeed = speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = new Vector2(_currentSpeed * moveDirection, _rb2d.velocity.y);

        if (jump)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, jumpForce);
            jump = false;
        }
    }

    void Update()
    {
        if (!slide && Input.GetKey(KeyCode.A))
        {
            moveDirection = -1;
            _spriteR.flipX = true;
        }
        else if (!slide && Input.GetKey(KeyCode.D))
        {
            moveDirection = 1;
            _spriteR.flipX = false;
        }

        if (grounded && !shoot && !melee)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    StartCoroutine(SlideDelay());
                }
                else if (!slide)
                {
                    _anim.SetBool("Idle", false);
                    _anim.SetBool("Jump", false);
                    _anim.SetBool("Run", true);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    StartCoroutine(SlideDelay());
                }
                else if (!slide)
                {
                    _anim.SetBool("Idle", false);
                    _anim.SetBool("Jump", false);
                    _anim.SetBool("Run", true);
                }
            }
            else if (!slide)
            {
                moveDirection = 0;
                _anim.SetBool("Run", false);
                _anim.SetBool("Jump", false);
                _anim.SetBool("Idle", true);
            }
        }

        if (grounded && Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            grounded = false;
            if (!shoot && !melee)
            {
                _anim.SetBool("Idle", false);
                _anim.SetBool("Run", false);
                _anim.SetBool("Jump", true);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            StartCoroutine(ShootDelay());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MeleeDelay());
        }


    }

    IEnumerator SlideDelay()
    {
        if (!slide)
        {
            slide = true;
            _currentSpeed = speed + (speed / 3f);
            _anim.SetBool("Run", false);
            _anim.SetBool("Slide", true);
            yield return new WaitForSeconds(0.6f);
            _anim.SetBool("Slide", false);
            slide = false;
            _currentSpeed = speed;
        }
    }

    IEnumerator ShootDelay()
    {
        if (!shoot && canShoot)
        {
            shoot = true;
            canShoot = false;
            _anim.SetBool("Idle", false);
            _anim.SetBool("Run", false);
            _anim.SetBool("Jump", false);
            _anim.SetBool("Shoot", true);
            yield return new WaitForSeconds(0.3f);
            _anim.SetBool("Shoot", false);
            _anim.SetBool("Idle", true);
            shoot = false;
            yield return new WaitForSeconds(0.2f);
            canShoot = true;
        }
    }

    IEnumerator MeleeDelay()
    {
        if (!melee && canMelee)
        {
            melee = true;
            canMelee = false;
            _anim.SetBool("Idle", false);
            _anim.SetBool("Run", false);
            _anim.SetBool("Jump", false);
            _anim.SetBool("Melee", true);
            yield return new WaitForSeconds(0.3f);
            _anim.SetBool("Melee", false);
            _anim.SetBool("Idle", true);
            melee = false;
            yield return new WaitForSeconds(0.2f);
            canMelee = true;
        }
    }

}

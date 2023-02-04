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
    CapsuleCollider2D _capCollider2D;

    float rightOffset;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spriteR = GetComponent<SpriteRenderer>();
        _capCollider2D = GetComponent<CapsuleCollider2D>();

        _currentSpeed = speed;

        rightOffset = _capCollider2D.offset.x;
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
            _capCollider2D.offset = new Vector2(-rightOffset, _capCollider2D.offset.y);
        }
        else if (!slide && Input.GetKey(KeyCode.D))
        {
            moveDirection = 1;
            _spriteR.flipX = false;
            _capCollider2D.offset = new Vector2(rightOffset, _capCollider2D.offset.y);
        }
        else if (!slide)
        {
            moveDirection = 0;
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

        if (grounded && !shoot && !melee)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    StartCoroutine(SlideDelayLeft());
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
                    StartCoroutine(SlideDelayRight());
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
                _anim.SetBool("Run", false);
                _anim.SetBool("Jump", false);
                _anim.SetBool("Idle", true);
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

    IEnumerator SlideDelayRight()
    {
        if (!slide)
        {
            slide = true;
            _currentSpeed = speed + (speed / 3f);
            _anim.SetBool("Run", false);
            _anim.SetBool("Slide", true);
            _capCollider2D.offset = new Vector2(-0.97f, -0.9449035f);
            _capCollider2D.size = new Vector2(2.96f, 3.008193f);
            yield return new WaitForSeconds(0.6f);
            _anim.SetBool("Slide", false);
            slide = false;
            _currentSpeed = speed;
            _capCollider2D.offset = new Vector2(-0.4729044f, 0.02565622f);
            _capCollider2D.size = new Vector2(1.970398f, 4.938585f);
        }
    }

    IEnumerator SlideDelayLeft()
    {
        if (!slide)
        {
            slide = true;
            _currentSpeed = speed + (speed / 3f);
            _anim.SetBool("Run", false);
            _anim.SetBool("Slide", true);
            _capCollider2D.offset = new Vector2(0.97f, -0.9449035f);
            _capCollider2D.size = new Vector2(2.96f, 3.008193f);
            yield return new WaitForSeconds(0.6f);
            _anim.SetBool("Slide", false);
            slide = false;
            _currentSpeed = speed;
            _capCollider2D.offset = new Vector2(-0.4729044f, 0.02565622f);
            _capCollider2D.size = new Vector2(1.970398f, 4.938585f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float _currentSpeed;
    public float jumpForce;
    int moveDirection;
    bool canMove;

    bool jump;
    bool slide;
    bool grounded;
    bool shoot;
    public static bool canShoot;
    bool melee = false;
    public static bool canMelee;

    public static bool isDead;

    Rigidbody2D _rb2d;
    Animator _anim;
    SpriteRenderer _spriteR;
    CapsuleCollider2D _capCollider2D;
    BoxCollider2D _boxCollider2D;

    float rightOffset;

    public GameObject rBullet;
    public GameObject lBullet;

    public GameObject slash_R;
    public GameObject slash_L;
    bool rightSlash;
    bool leftSlash;

    [SerializeField] GameObject pofEffect;
    GameObject instantiatedPof;

    [SerializeField] GameObject MeleeHitEffect;
    GameObject instantiatedHit;
    bool canHitEffect;
    bool hitEnemy;

    [SerializeField] GameObject bossHealthBarGameObject;
    [SerializeField] Slider bossHealthBar;

    public static bool bossEnter;
    public Transform bossFightSpawnPos;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spriteR = GetComponent<SpriteRenderer>();
        _capCollider2D = GetComponent<CapsuleCollider2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

        _currentSpeed = speed;

        rightOffset = _capCollider2D.offset.x;

        jump = false;
        slide = false;
        grounded = true;
        shoot = false;
        canShoot = true;
        melee = false;
        canMelee = true;
        canMove = true;

        isDead = false;

        canHitEffect = false;
        hitEnemy = false;

        bossEnter = false;

        SceneManager.currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("CurrentScene", SceneManager.currentScene);
        PlayerPrefs.Save();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            instantiatedPof = Instantiate(pofEffect, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
            Destroy(instantiatedPof, 0.5f);
            AudioSource.PlayClipAtPoint(SoundManager.Instance.audio[0], gameObject.transform.position);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            isDead = true;
            hitEnemy = true;
        }
        else if (collision.gameObject.CompareTag("Bubble"))
        {
            isDead = true;
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hitEnemy = true;
            if (!melee)
            {
                isDead = true;
            }
        }

        if (collision.gameObject.CompareTag("BossArea") && !bossEnter)
        {
            bossEnter = true;
            bossHealthBarGameObject.SetActive(true);
            StartCoroutine(ThrillerDelay());
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        isDead = true;
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
        
        
        if (!isDead && canMove)
        {
            if (!slide && Input.GetKey(KeyCode.A))
            {
                moveDirection = -1;
                _spriteR.flipX = true;
                _capCollider2D.offset = new Vector2(-rightOffset, _capCollider2D.offset.y);
                _boxCollider2D.offset = new Vector2(-rightOffset, _boxCollider2D.offset.y);

                rBullet.SetActive(false);
                lBullet.SetActive(true);

                rightSlash = false;
                leftSlash = true;
                //slash_R.SetActive(false);
                //slash_L.SetActive(true);
            }
            else if (!slide && Input.GetKey(KeyCode.D))
            {
                moveDirection = 1;
                _spriteR.flipX = false;
                _capCollider2D.offset = new Vector2(rightOffset, _capCollider2D.offset.y);
                _boxCollider2D.offset = new Vector2(rightOffset, _boxCollider2D.offset.y);

                lBullet.SetActive(false);
                rBullet.SetActive(true);

                leftSlash = false;
                rightSlash = true;
                //slash_L.SetActive(false);
                //slash_R.SetActive(true);
                
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
                AudioSource.PlayClipAtPoint(SoundManager.Instance.audio[1], gameObject.transform.position);
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
        else if(isDead)
        {
            canMove = false;
            isDead = false;
            _anim.SetBool("Run", false);
            _anim.SetBool("Jump", false);
            _anim.SetBool("Idle", false);
            _anim.SetBool("Shoot", false);
            _anim.SetBool("Slide", false);
            _anim.SetBool("Melee", false);
            _anim.SetBool("Dead", true);
            moveDirection = 0;
            
            AudioSource.PlayClipAtPoint(SoundManager.Instance.audio[6], gameObject.transform.position);
            StartCoroutine(RestartDelay());
        }

        
        if (canHitEffect && hitEnemy)
        {
            canHitEffect = false;
            hitEnemy = false;
            if (rightSlash)
            {
                instantiatedHit = Instantiate(MeleeHitEffect, new Vector3(transform.position.x + 1.2f, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (leftSlash)
            {
                instantiatedHit = Instantiate(MeleeHitEffect, new Vector3(transform.position.x - 1.2f, transform.position.y, transform.position.z), Quaternion.identity);
            }
            Destroy(instantiatedHit, 0.5f);
        }

        bossHealthBar.value = Boss.bossHealth;

    }
    //E???er karakter kayarken kafas???n???n ???st???nden ge???en bir ???eye ???l???yorsa karakterin box collider ??? i???in slide fonksiyonlar???n???n i???ine scale set edilecek.
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
            AudioSource.PlayClipAtPoint(SoundManager.Instance.audio[2], gameObject.transform.position);
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
            AudioSource.PlayClipAtPoint(SoundManager.Instance.audio[7], gameObject.transform.position);
            yield return new WaitForSeconds(0.3f);
            _anim.SetBool("Shoot", false);
            _anim.SetBool("Idle", true);
            shoot = false;
            yield return new WaitForSeconds(0.2f);
            canShoot = true;
            BulletSpawner_R.canSpawnBullet_R = true;
            BulletSpawner_L.canSpawnBullet_L = true;
        }
    }

    IEnumerator MeleeDelay()
    {
        if (!melee && canMelee)
        {
            
            melee = true;
            canMelee = false;
            canHitEffect = true;
            _anim.SetBool("Idle", false);
            _anim.SetBool("Run", false);
            _anim.SetBool("Jump", false);
            _anim.SetBool("Melee", true);

            if (rightSlash)
            {
                slash_R.SetActive(true);
            }
            else if (leftSlash)
            {
                slash_L.SetActive(true);
            }
            AudioSource.PlayClipAtPoint(SoundManager.Instance.audio[2], gameObject.transform.position);
            yield return new WaitForSeconds(0.3f);
            Debug.Log(0);
            slash_R.SetActive(false);
            slash_L.SetActive(false);
            _anim.SetBool("Melee", false);
            _anim.SetBool("Idle", true);
            melee = false;
            Debug.Log(1);
            yield return new WaitForSeconds(0.2f);
            Debug.Log(2);
            canMelee = true;
        }
    }


    IEnumerator RestartDelay()
    {
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ThrillerDelay()
    {
        AudioSource.PlayClipAtPoint(SoundManager.Instance.audio[8], gameObject.transform.position);
        yield return new WaitForSeconds(2f);
        AudioSource.PlayClipAtPoint(SoundManager.Instance.audio[9], gameObject.transform.position);
    }

}

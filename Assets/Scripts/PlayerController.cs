using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private float _inputHorizontal;


    [Header("Movement")]
    [SerializeField] public float saruSpeed = 7;
    [SerializeField] public float saruSprint = 1;
   
    [Header("Jump")]
    public bool doubleJump = true;
    public float saruJump = 12;
    public float weakJump = 0.9f;
   
    [Header("Cloud")]
    [SerializeField] private Transform kintonSpawn;
    [SerializeField] private GameObject kintonPrefab;


    [Header("Dash")]
    [SerializeField] private float _dashForce = 20;
    [SerializeField] private float _dashDuration = 0.2f;
    [SerializeField] private float _dashCoolDown = 2f;
    [SerializeField] private bool _canDash = true;
    [SerializeField] private bool _isDashing = false;


    [Header("Clon")]
    [SerializeField] private Transform _clonSpawn;
    [SerializeField] private GameObject _clonPrefab;
    [SerializeField] private bool _isCloned;


    /*[Header("Ground")]
    [SerializeField] private LayerMask _ground;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _canDoubleJump = true;
    [SerializeField] private float _groundRadius = 1;
    [SerializeField] private Transform _groundSpawn;*/


    [Header("Attack")]
    [SerializeField] private bool _isNormalAttacking = false;
    [SerializeField] private Transform _hitBoxPosition;
    [SerializeField] private float _attackRadius = 1;
    [SerializeField] private LayerMask _enemyLayer;
   
    [Header("Shoot")]
    [SerializeField] private GameObject _bananaPrefab;
    [SerializeField] private Transform _bananaSpawn;
    [SerializeField] private float _bananaAnimation = 1;


    [Header("Life")]
    [SerializeField] private float maxHealth = 20;
    [SerializeField] private float currentHealth;
    [SerializeField] private float deathDelay = 3; 
    public bool isDead = false;
   


    //Componentes Inspector
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private GroundSensor _groundSensor;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;
    private AudioSource _audioSource;
    public AudioClip _deathSFX;
    public AudioClip _punchSFX;
    public AudioClip _shootSFX;
    public AudioClip _dashSFX;
    public AudioClip _jumpSFX;
    //private Pollito _pollitoScript;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        //_pollitoScript = GetComponent<Pollito>();
        
    }
   
    void Update()
    {


        if(isDead)
        {
            return;
        }


        if(_isNormalAttacking)
        {
            return;
        }


        //Bloqueo de Inputs mientras se Dashea
        if(_isDashing)
        {
            return;
        }


        _inputHorizontal = Input.GetAxisRaw("Horizontal");


        Movement();
       
        Sprint();


        //Clon();


        if(Input.GetButtonDown("Shoot"))
        {
            StartCoroutine(Shoot());
        }


        //Fuerza de salto
        if(_groundSensor.isGrounded)
        {
            saruJump = 12;
        }
        else
        {
            saruJump = 12*weakJump;
        }


        //Condiciones del Golpe
        if(Input.GetButtonDown("Attack"))
        {
            NormalAttack();
        }


        //Condiciones del Salto
        if(Input.GetButtonDown("Jump"))
        {
            
            if(_groundSensor.isGrounded || _groundSensor.canDoubleJump)
            {
                Jump();
            }
        }

        //Condicion del Dash
        if(Input.GetButtonDown("Dash") && _canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {  
        if(_isDashing)
        {
            return;
        }
        _rigidBody.velocity = new Vector2(_inputHorizontal * saruSpeed * saruSprint, _rigidBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Chick"))
        {
            Death();
        }
    }








    //Lista de acciones
    void Sprint()
    {
        if(Input.GetButton("Sprint") && _groundSensor.isGrounded)
        {
            saruSprint = 1.50f;
        }
        else if(!Input.GetButtonUp("Sprint") && _groundSensor.isGrounded)
        {
            saruSprint = 1;
        }
    }


    void Jump()
    {
        if(!_groundSensor.isGrounded)
        {
            _groundSensor.canDoubleJump = false;
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            Instantiate(kintonPrefab.gameObject, kintonSpawn.position, kintonSpawn.rotation);
        }
        _rigidBody.AddForce(Vector2.up * saruJump, ForceMode2D.Impulse);
        _audioSource.PlayOneShot(_jumpSFX);
    }


    void Movement()
    {
        _animator.SetBool("IsJumping", !_groundSensor.isGrounded);


        if(_inputHorizontal > 0)
        {
            _rigidBody.velocity = new Vector2(_inputHorizontal * saruSpeed * saruSprint, _rigidBody.velocity.y);
            _animator.SetBool("IsRunning", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(_inputHorizontal < 0)
        {
            _rigidBody.velocity = new Vector2(_inputHorizontal * saruSpeed * saruSprint, _rigidBody.velocity.y);
            _animator.SetBool("IsRunning", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }        
    }


    IEnumerator Dash()
    {
        float gravity = _rigidBody.gravityScale;
        _rigidBody.gravityScale = 0;
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x ,0);
       
       
        _isDashing = true;
        _audioSource.PlayOneShot(_dashSFX);
        _animator.SetBool("IsDashing", true);
        _canDash = false;
        _rigidBody.AddForce(transform.right*_dashForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_dashDuration);


        _rigidBody.gravityScale = gravity;
        _isDashing = false;
        _animator.SetBool("IsDashing", false);
        yield return new WaitForSeconds(_dashCoolDown);
        _canDash = true;
    }


    /*void Clon()
    {
        if(Input.GetButtonDown("Clon"))
        {
            _rigidBody.AddForce(transform.right*_dashForce, ForceMode2D.Impulse);
            Instantiate(_clonPrefab.gameObject, _clonSpawn.position, _clonSpawn.rotation);
            _isCloned = true;
        }
    }
    */


    /*void Ground()
    {
        Collision2D[] collision = Physics2D.OverlapBox(_groundSpawn.position, _groundRadius, _ground);
        foreach(Collision2D groundeded in collision)
        {
            _isGrounded = true;
        }
    }*/


    public void Death()
    {
        isDead = true;
        _rigidBody.AddForce(Vector2.up * saruJump, ForceMode2D.Impulse);
        _animator.SetTrigger("IsDead");
        _boxCollider.enabled = false;

        StartCoroutine(DeathSound());
    }


    void NormalAttack()
    {
        _animator.SetTrigger("IsAttacking");
        _audioSource.PlayOneShot(_punchSFX);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_hitBoxPosition.position, _attackRadius, _enemyLayer);
        foreach(Collider2D enemy in enemies)
        {
            Pollito _pollitoScript = enemy.GetComponent<Pollito>();
            //_pollitoScript.ChickDeath();
            StartCoroutine(_pollitoScript.ChickDeath());
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;


        //Gizmos.DrawWireBox(_groundSpawn.position, _groundRadius);
        Gizmos.DrawWireSphere(_hitBoxPosition.position, _attackRadius);
    }


    IEnumerator Shoot()
    {
        _animator.SetTrigger("IsShooting");
        yield return new WaitForSeconds(_bananaAnimation);
        Instantiate(_bananaPrefab, _bananaSpawn.position, _bananaSpawn.rotation);
        _audioSource.PlayOneShot(_shootSFX);
    }


    /*void TakeDamage(float damage)
    {
       
    }
    */

    IEnumerator DeathSound()
    {
        _audioSource.PlayOneShot(_deathSFX);
        yield return new WaitForSeconds(deathDelay);

        Destroy(gameObject);
    }
   


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pollito : MonoBehaviour
{
    private float _chickSpeed = 5;
    private float _chickDirection;
    private AudioSource _audioSource;
    public AudioClip _chickDeathSFX;
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    public GrullaTrap _grullaTrap;
    private SpriteRenderer _spriteRenderer;
    private PlayerController _playerController;
    public float chickDamage = 1;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _playerController = FindObjectOfType<PlayerController>();
        _chickDirection = _grullaTrap.plumillaDirection;
    }

    void Start()
    {
        
    }
   
    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(_chickSpeed * _chickDirection, _rigidBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.layer == 8)
        {
            _playerController.TakeDamage(chickDamage);
            StartCoroutine(ChickDeath());
            //_playerController.Death();
        }
    }

    public IEnumerator ChickDeath()
    {
        float chickDeathDelay = 1;
        _chickSpeed = 0;
        _spriteRenderer.enabled = false;
        _boxCollider.enabled = false;
        _rigidBody.gravityScale = 0;
        _audioSource.PlayOneShot(_chickDeathSFX);
        yield return new WaitForSeconds(chickDeathDelay);
        Destroy(gameObject);
    }
}


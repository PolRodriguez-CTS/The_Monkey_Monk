using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    private int _mouseDamage = 2;
    public int _mousePoints = 500;
    public int direction = 1;
    private float speed = 8;

    private GameManager _gameManager;
    private PlayerController _playerController;
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    public AudioClip _ratDeathSFX;
    private bool _isFlipped = false;

    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = FindObjectOfType<GameManager>(); GetComponent<GameManager>();
        _playerController = FindObjectOfType<PlayerController>(); GetComponent<PlayerController>();
        _audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.layer == 6 || collision.gameObject.CompareTag("Player")) && !_isFlipped)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            direction *= -1;
            _isFlipped = true;
            if (collision.gameObject.CompareTag("Player"))
                {
                    _playerController.TakeDamage(_mouseDamage);
                }
        }
        else if ((collision.gameObject.layer == 6 || collision.gameObject.CompareTag("Player")) && _isFlipped)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            direction *= -1;
            _isFlipped = false;
            if (collision.gameObject.CompareTag("Player"))
            {
                _playerController.TakeDamage(_mouseDamage);
            }
        }
    }
    
    public IEnumerator MouseDeath()
    {
        float ratDelay = 1;
        speed = 0;
        _spriteRenderer.enabled = false;
        _boxCollider2D.enabled = false;
        _rigidBody.gravityScale = 0;
        _audioSource.PlayOneShot(_ratDeathSFX);
        yield return new WaitForSeconds(ratDelay);
        Destroy(gameObject);
    }

}

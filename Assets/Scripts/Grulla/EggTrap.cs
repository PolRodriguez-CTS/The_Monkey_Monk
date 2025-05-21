using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggTrap : MonoBehaviour
{
   
    [SerializeField] private Transform _eggPostition;
    [SerializeField] private GameObject _pollito;   
 
 
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    public AudioClip _eggCrackSFX;
    private SpriteRenderer _spriteRenderer;
    private float eggDamage = 0.5f;
    private PlayerController _playerController;
    public GrullaTrap _grullaDirection;
    public Transform _grullaRotation;
    
    
    
    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerController = FindObjectOfType<PlayerController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            StartCoroutine(PollitoGenerator());
        }
        if(collision.gameObject.layer == 8)
        {
            _playerController.TakeDamage(eggDamage);
            Destroy(gameObject);
            //_playerController.Death();
        }
    }

    IEnumerator PollitoGenerator()
    {   
        float crackDelay = 1;
        _spriteRenderer.enabled = false;
        _boxCollider.enabled = false;
        _rigidBody.gravityScale = 0;

        GameObject pollito = Instantiate(_pollito, _eggPostition.position, _grullaRotation.rotation);
        Pollito _pollitoScript = _pollito.GetComponent<Pollito>();
        _pollitoScript._grullaTrap = _grullaDirection;

        _audioSource.PlayOneShot(_eggCrackSFX);
        yield return new WaitForSeconds(crackDelay);
        Destroy(gameObject);
    }
}

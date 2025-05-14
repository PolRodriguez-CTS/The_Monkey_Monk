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
    
    
    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            StartCoroutine(PollitoGenerator());
        }

        if(collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator PollitoGenerator()
    {   
        float crackDelay = 1;
        _spriteRenderer.enabled = false;
        _boxCollider.enabled = false;
        _rigidBody.gravityScale = 0;
        Instantiate(_pollito, _eggPostition.position, _eggPostition.rotation);
        _audioSource.PlayOneShot(_eggCrackSFX);
        yield return new WaitForSeconds(crackDelay);
        Destroy(gameObject);
    }

}

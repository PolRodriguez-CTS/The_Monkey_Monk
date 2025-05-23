using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumplingPowerUp : MonoBehaviour
{

    private float _timerDumpling = 2;
    private int _dumplingPoints = 200;
    private BoxCollider2D _boxCollider;
    private PlayerController _playerController;
    private GameManager _gameManager;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    public AudioClip _dumplingSFX;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {   
            StartCoroutine(Dumpling());
        }
    } 

    IEnumerator Dumpling()
    {
        _gameManager.AddPoints(_dumplingPoints);
        _spriteRenderer.enabled = false;
        _playerController.currentHealth += 2;
        _playerController.UpdateHealthBar();
        _boxCollider.enabled = false;
        _audioSource.PlayOneShot(_dumplingSFX);

        yield return new WaitForSeconds(_timerDumpling);

        Destroy(gameObject);
        
    }

    



    
}

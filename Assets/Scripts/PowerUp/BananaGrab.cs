using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaGrab : MonoBehaviour
{

    private float _timerBanana = 2;

    private PlayerController _playerController;
    private GameManager _gameManager;
    private BoxCollider2D _boxCollider;
    private int _bananaPoints = 150; 
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    public AudioClip _bananaSFX;


    void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Banana());
        }
    }

    IEnumerator Banana()
    {
        _playerController._bananaItem ++;
        _gameManager.AddBanana();
        _gameManager.AddPoints(_bananaPoints);
        _spriteRenderer.enabled = false;
        _boxCollider.enabled = false;
        _audioSource.PlayOneShot(_bananaSFX);

        yield return new WaitForSeconds(_timerBanana);

        Destroy(gameObject);
        
    }


}

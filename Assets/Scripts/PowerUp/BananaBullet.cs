using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BananaBullet : MonoBehaviour
{
    public float speed = -300;
    [SerializeField] private float _bananaSpeed = 10; 
    
    private Rigidbody2D _rigidBody;
    private GameManager _gameManager;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Start()
    {
        _rigidBody.AddForce(transform.right * _bananaSpeed, ForceMode2D.Impulse);
    }
    
    void FixedUpdate()
    {
        transform.Rotate(0,0,speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 3)
        {
            BananaDeath();
        }
        if (collider.gameObject.layer == 6)
        {
            //llamar la función de muerte o de daño para enemigos
        }
        if (collider.gameObject.CompareTag("Chick"))
        {
            Pollito chickScript = collider.gameObject.GetComponent<Pollito>();
            StartCoroutine(chickScript.ChickDeath());
            _gameManager.AddPoints(_gameManager.pollitoPoints);
            BananaDeath();
        }
        /*if (collider.gameObject.CompareTag("Mouse"))
        {
            MouseMovement _mouseScript = collider.gameObject.GetComponent<MouseMovement>();
            StartCoroutine(_mouseScript.MouseDeath());
            _gameManager.AddPoints(_mouseScript._mousePoints);
            BananaDeath();
        }*/
    }

    void BananaDeath()
    {
        Destroy(gameObject);
    }

  
}

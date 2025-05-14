using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkMovement : MonoBehaviour
{
    [Header ("Movement")]
    [SerializeField] public int monkDirection = -1;
    [SerializeField] private float monkSpeed = 3.5f;
    
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    public bool _isFliped = false;
    

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
    }

    
    void OnTriggerEnter2D (Collider2D collider)
    {
        /*if(collider.gameObject.layer == 6 && !_isFliped)
        {
            transform.rotation = Quaternion.Euler (0, 180, 0);
            monkDirection *= -1;
            _isFliped = true;
        }
        else if(collider.gameObject.layer == 6 && _isFliped)
        {
            transform.rotation = Quaternion.Euler (0, 0, 0);
            monkDirection *= -1;
            _isFliped = false;
        }*/

        if(collider.gameObject.layer == 6)
        {
            
            if(!_isFliped)
            {
                transform.rotation = Quaternion.Euler (0, 180, 0);
                monkDirection *= -1;
                _isFliped = true;
            }
            else
            {
                transform.rotation = Quaternion.Euler (0, 0, 0);
                monkDirection *= -1;
                _isFliped = false;
            }
            
        }
    }
    
    void Movement()
    {
        _rigidBody.velocity = new Vector2(monkDirection * monkSpeed, _rigidBody.velocity.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BananaBullet : MonoBehaviour
{
    public float speed = -300;
    [SerializeField] private float _bananaSpeed = 10; 
    
    private Rigidbody2D _rigidBody;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rigidBody.velocity = new Vector2(_bananaSpeed, _rigidBody.velocity.y);
    }
    
    void FixedUpdate()
    {
        transform.Rotate(0,0,speed * Time.deltaTime);
    }
}

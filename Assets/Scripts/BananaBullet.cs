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
        _rigidBody.AddForce(transform.right * _bananaSpeed, ForceMode2D.Impulse);
    }
    
    void FixedUpdate()
    {
        transform.Rotate(0,0,speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            BananaDeath();
        }
        if(collider.gameObject.layer == 6)
        {
            //llamar la función de muerte o de daño para enemigos
        }
    }

    void BananaDeath()
    {
        Destroy(gameObject);
    }

  
}

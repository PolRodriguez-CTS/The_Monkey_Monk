using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrullaTrap : MonoBehaviour
{

    public float plumillaSpeed = 4;
    public float plumillaDirection = 1;

    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            plumillaDirection *= -1;

        }
    }
    
    void FixedUpdate()
    {
        GrullaMovement();
    }

    void GrullaMovement()
    {
        _rigidBody.velocity = new Vector2(plumillaSpeed * plumillaDirection, _rigidBody.velocity.y);
    }

}

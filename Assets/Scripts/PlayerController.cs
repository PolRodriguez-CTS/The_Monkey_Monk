using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float playerSpeed = 5;
    public float sprint = 0;
    private float horizontalInput;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(horizontalInput * playerSpeed, _rigidBody.velocity.y);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float saruSpeed = 4;
    public float saruJump = 20;
    public float saruSprint = 1;

    

    private Rigidbody2D _rigidBody;
    private GroundSensor _groundSensor;
    private Animator _animator;

    private float inputHorizontal;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
    }
    
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        Rotation();
        
        Sprint();

        Jump();

        //Dash();
        
    }

    void FixedUpdate()
    {
        Movement();
    }


 
    //Lista de acciones
    void Movement()
    {
        _rigidBody.velocity = new Vector2(inputHorizontal * saruSpeed * saruSprint, _rigidBody.velocity.y);
    }

    void Sprint()
    {
        if(Input.GetButton("Sprint"))
        {
            saruSprint = 1.75f;
        }
        else if(!Input.GetButtonUp("Sprint"))
        {
            saruSprint = 1;
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && _groundSensor._isGrounded)
        {
            _rigidBody.AddForce(Vector2.up * saruJump, ForceMode2D.Impulse);
        }
    }

    void Rotation()
    {
        if(inputHorizontal > 0)
        {
            _animator.SetBool("IsRunning", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(inputHorizontal < 0)
        {
            _animator.SetBool("IsRunning", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }

        
        
    }
    

        
    
    /*void Dash()
    {
        if(Input.GetButtonDown("Dash"))
        {
            _rigidBody.AddForce(Vector2. * saruJump, ForceMode2D.Impulse);
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public bool isGrounded;
    public bool canDoubleJump = true;
    private PlayerController _playerController;
    

    void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGrounded = true;
            canDoubleJump = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        
        isGrounded = false;
    }


}
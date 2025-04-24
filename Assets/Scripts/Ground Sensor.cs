using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public bool isGrounded;
    public float jumpBuffering = 1f;
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
            _playerController.doubleJump = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        //StartCoroutine(JumpBuffering());
        isGrounded = false;
    }

    IEnumerator JumpBuffering()
    {
        yield return new WaitForSeconds(jumpBuffering); 
    }
}

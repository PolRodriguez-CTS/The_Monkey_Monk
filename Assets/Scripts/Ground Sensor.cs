using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public bool _isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3 || collider.gameObject.CompareTag("Dragon"))
        {
            _isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3 || collider.gameObject.CompareTag("Dragon"))
        {
            _isGrounded = false;
        }
    }
}

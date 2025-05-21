using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private BoxCollider2D _boxCollider;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 8)
        {
            Debug.Log("Has ganado monicaco");
            //aquí ya has ganado
        }
    }
}

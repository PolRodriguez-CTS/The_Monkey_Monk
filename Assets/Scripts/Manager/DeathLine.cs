using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLine : MonoBehaviour
{

    private PlayerController _playerController;
    private BoxCollider2D _boxCollider;

    void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine(_playerController.MonkeyDeath());
        }
    }

}
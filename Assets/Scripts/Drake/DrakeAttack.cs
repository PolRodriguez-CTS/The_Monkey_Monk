using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrakeAttack : MonoBehaviour
{
    private float _drakeSpeed = 7.5f;
    private int _drakeDirection;
    private float _drakeDestroy = 5;
    private Rigidbody2D _rigidBody2D;
    private MonkMovement _monkMovement;

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _monkMovement = FindObjectOfType<MonkMovement>().GetComponent<MonkMovement>();
    }

    void Start()
    {
        StartCoroutine(DrakeDestroy());
        _drakeDirection = _monkMovement.monkDirection;
    }

    void Update()
    {
        _rigidBody2D.velocity = new Vector2(_drakeSpeed * _drakeDirection, _rigidBody2D.velocity.y);
    }

    IEnumerator DrakeDestroy()
    {
        yield return new WaitForSeconds(_drakeDestroy);
        Destroy(gameObject);
    }
}

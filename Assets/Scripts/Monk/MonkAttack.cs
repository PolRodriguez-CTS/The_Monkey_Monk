using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkAttack : MonoBehaviour
{
    private Collider2D _collider2D;
    public GameObject drakePrefab;
    public Transform drakeSpawn;
    public Transform saru;
    public float timer = 0;
    private float cooldown = 3;
    private bool _playerInRange = false;
    public float attackRange = 4;

    void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    void Start()
    {
        timer = cooldown;
    }

    void Update()
    {
        if(saru == null)
        {
            return;
        }

        if(Vector3.Distance(transform.position, saru.position) <= attackRange)
        {
            if(timer >= cooldown)
            {
                Attack();
            }

            if(_playerInRange)
            {
                timer += Time.deltaTime;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 8)
        {
            _playerInRange = true;
        }
        
    }
    
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 8)
        {
            _playerInRange = false;
            timer = 0;
        }
        
    }

    void Attack()
    {
        Instantiate(drakePrefab, drakeSpawn.position, drakeSpawn.rotation);
        timer = 0;
    }
}

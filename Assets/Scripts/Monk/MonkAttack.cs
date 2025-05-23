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
    private float cooldown = 5;
    //private bool _playerInRange = false;
    private float attackRange = 20;

    void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        saru = GameObject.FindWithTag("Player").transform;
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
            Vector3 directionToPlayer = saru.position - transform.position;
            float angleToPlayer = Vector3.Angle(transform.right, directionToPlayer);

            if(angleToPlayer > 100)
            {
                timer += Time.deltaTime;
                if(timer >= cooldown)
                {
                    Attack();
                }
            } 
        }
        else
            {
                timer = 0;
            }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        
    }

    /*void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 8)
        {
            _playerInRange = true;
        }
        
    }*/
    
    /*void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 8)
        {
            _playerInRange = false;
            timer = 0;
        }
        
    }*/

    void Attack()
    {
        Instantiate(drakePrefab, drakeSpawn.position, drakeSpawn.rotation);
        timer = 0;
    }
}

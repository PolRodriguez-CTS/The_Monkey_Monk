using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrullaTrap : MonoBehaviour
{

    public float plumillaSpeed = 6;
    public float plumillaDirection = -1;
    
    [SerializeField] private Transform _eggGeneration;
    [SerializeField] private GameObject _eggPrefab;
    [SerializeField] private bool _isFliped = false;


    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    //public BoxCollider2D _boxColliderPlayer;



    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        //_boxColliderPlayer = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6 && !_isFliped)
        {
            
            transform.rotation = Quaternion.Euler(0, 180, 0);
            plumillaDirection *= -1;
            _isFliped = true;
        }
        else if(collider.gameObject.layer == 6 && _isFliped)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            plumillaDirection *= -1;
            _isFliped = false;
        }

        if(collider.gameObject.CompareTag("Player"))
        {
           GameObject huevo = Instantiate(_eggPrefab, _eggGeneration.position, _eggGeneration.rotation);
           EggTrap _eggScript = huevo.GetComponent<EggTrap>();
           _eggScript._grullaDirection = this;
           _eggScript._grullaRotation = transform;
        }
    }
    
    void FixedUpdate()
    {
        GrullaMovement();
    }

    void GrullaMovement()
    {
        _rigidBody.velocity = new Vector2(plumillaSpeed * plumillaDirection, _rigidBody.velocity.y);
    }
}

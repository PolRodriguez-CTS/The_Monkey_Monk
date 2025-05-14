using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasos : MonoBehaviour
{

    //Para el sonido de caminar unicamente
    [Header("Pasos")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _footStepsAuido;
    private GroundSensor _groundSensor;

    private bool _alreadyPlaying = false;
    private ParticleSystem _particleSystem;
    private Transform _particlesTransform;
    private Vector3 _particlesPosition;


    void Awake()
    {
        _groundSensor = GetComponentInChildren<GroundSensor>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _particlesTransform = _particleSystem.transform;
        _particlesPosition = _particlesTransform.localPosition;

    }
    
    void Start()
    {
        _audioSource.loop = true;
        _audioSource.clip = _footStepsAuido;
    }


    void Update()
    {
        FootStepsSound();
    }

    void FootStepsSound()
    {
        if(_groundSensor.isGrounded && Input.GetAxisRaw("Horizontal") != 0 && !_alreadyPlaying)
        {
            _particlesTransform.SetParent(gameObject.transform);
            _particlesTransform.localPosition = _particlesPosition;
            _particlesTransform.rotation = transform.rotation;
            _audioSource.Play();
            _particleSystem.Play();
            _alreadyPlaying = true;
        }
        else if(!_groundSensor.isGrounded || Input.GetAxisRaw("Horizontal") == 0)
        {
            _particlesTransform.SetParent(null);
            _audioSource.Stop();
            _particleSystem.Stop();
            _alreadyPlaying = false;
        }
    }
}

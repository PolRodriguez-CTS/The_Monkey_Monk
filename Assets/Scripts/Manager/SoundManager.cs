using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip bgm;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        _audioSource.clip = bgm;
        _audioSource.Play();

    }

    public void PauseBGM()
    {
        _audioSource.Pause();
    }

    public void ResumeBGM()
    {
        _audioSource.Play();
    }
}

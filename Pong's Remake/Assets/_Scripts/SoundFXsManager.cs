using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXsManager : MonoBehaviour
{
    [SerializeField] AudioClip scoreSFX;
    [SerializeField] AudioClip servingSFX;
    [SerializeField] AudioClip bounceSFX;

    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        GetComponents();
    }
    void GetComponents()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayScoreSFX()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(scoreSFX);
    }
    public void PlayServingSFX()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(servingSFX);
    }

    public void PlayBounceSFX()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(bounceSFX);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

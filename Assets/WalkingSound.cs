using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public AudioClip walkingSound;  
    private AudioSource audioSource;  

    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        if (GetComponent<Rigidbody>().velocity.magnitude > 0.1f)  
        {
            
            if (!audioSource.isPlaying)
            {
                audioSource.clip = walkingSound;
                audioSource.Play();
            }
        }
        else
        {
   
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
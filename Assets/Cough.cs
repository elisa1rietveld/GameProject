using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cough : MonoBehaviour

 {
    
    private AudioSource audioSource;

    
    public AudioClip coughClip;

    
    public float coughInterval = 30f;

    private void Start()
    {
       
        audioSource = GetComponent<AudioSource>();

        
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        
        StartCoroutine(PlayCoughSoundAtInterval());
    }

    private IEnumerator PlayCoughSoundAtInterval()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(coughInterval);

            
            audioSource.PlayOneShot(coughClip);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmButton : MonoBehaviour
  {
    public AudioClip alarmSound;  // Reference to the alarm sound clip
    private AudioSource audioSource;  // AudioSource to play the sound

    void Start()
    {
        // Get or add an AudioSource component to this GameObject
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check if the player presses the "E" key
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayAlarm();
        }
    }

    void PlayAlarm()
    {
        // Play the alarm sound if it's set
        if (alarmSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(alarmSound);
        }
        else
        {
            Debug.LogWarning("No alarm sound set or AudioSource missing.");
        }
    }
}
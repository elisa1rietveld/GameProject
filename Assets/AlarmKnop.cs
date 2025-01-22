using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmKnop : MonoBehaviour
{
    public AudioClip fireAlarmSound;
    private AudioSource audioSource;
    private bool isPressed = false;
    private float pressTime = 0f;
    public float pressThreshold = 2f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isPressed = true;
                    pressTime += Time.deltaTime;

                    if (pressTime >= pressThreshold && !audioSource.isPlaying)
                    {
                        TriggerFireAlarm();
                        isPressed = false;
                    }
                }
            }
        }
        else
        {
            isPressed = false;
            pressTime = 0f;
        }
    }

    private void TriggerFireAlarm()
    {
        if (fireAlarmSound != null && audioSource != null)
        {
            Debug.Log("Alarm klinkt!");
            audioSource.clip = fireAlarmSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Brandalarmgeluid of AudioSource niet gevonden!");
        }
    }
}

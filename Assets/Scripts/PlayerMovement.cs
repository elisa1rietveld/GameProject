using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float mouseSensitivity = 100f; 
    private float rotationX = 0f;

    
    public AudioClip walkingSound;  
    private AudioSource audioSource; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
       
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical"); 

        
        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            transform.position += move * moveSpeed * Time.deltaTime;

           
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

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; 

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); 

        transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y + mouseX, 0f);
    }
}

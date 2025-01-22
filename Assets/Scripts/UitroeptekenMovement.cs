using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UitroeptekenMovement : MonoBehaviour

  {
    public float floatSpeed = 2.0f;  
    public float floatHeight = 0.5f; 

    private Vector3 startPosition;

    void Start()
    {
        // Sla de startpositie op
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Stel de nieuwe positie in
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
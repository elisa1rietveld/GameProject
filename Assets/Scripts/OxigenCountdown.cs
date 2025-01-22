using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class OxigenCountdown : MonoBehaviour
{
    public TextMeshProUGUI tmpText; // Verwijs naar de TextMeshPro-component in je scène
    private float countdownTime = 180f; // 3 minuten in seconden
    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
        UpdateText();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            if (currentTime < 0)
            {
                currentTime = 0; // Zorg ervoor dat het niet negatief wordt
            }

            UpdateText();
        }
        else
        {
            EndGame();
        }
    }

    void UpdateText()
    {
        float percentage = (currentTime / countdownTime) * 100;
        tmpText.text = $"{percentage:0}%";
    }

    void EndGame()
    {
        Debug.Log("Het spel is voorbij!");
        // Stop het spel (alleen werkt dit in de editor)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit(); // Sluit de applicatie bij build
        #endif
    }
}
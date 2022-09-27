using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerX : MonoBehaviour
{
    // Variables
    public float timeLeft; // Holds amount of time left
    public bool timerOn = false; // Checks if the timer is active

    public Text timerText; // Timer text
    
    // Start is called before the first frame update
    void Start()
    {
        timerOn = true; // Turn on the timer
    }

    // Update is called once per frame
    void Update()
    {
        // Check if time left > 
        if (timerOn) // If the timer is on and...
        {
            if (timeLeft > 0) // ...If there is time left
            {
                timeLeft -= Time.deltaTime; // Then decrease the remaining time/timer by 1 second
                UpdateTimer(timeLeft); // Then update the current time
            }
            else
            {
                Debug.Log("Time is up!");
                timeLeft = 0; // Set the remaining time to zero
                timerOn = false; // Turn off the timer
            }
        }
    }

    //
    void UpdateTimer(float currentTime)
    {
        currentTime += 1; // Increase current time by 1 second
        float seconds = Mathf.RoundToInt(currentTime % 60); // Find the remaining time in seconds

        // Show the time on screen
        timerText.text = string.Format("Timer: " + seconds);
    }
}

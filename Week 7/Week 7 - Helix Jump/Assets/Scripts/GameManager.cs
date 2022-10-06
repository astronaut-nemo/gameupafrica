using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    public static bool isGameOver = false; // Checks if game is over
    public static bool isLevelComplete = false; // Check if level is completed

    // References
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isGameOver = isLevelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Game Over
        if(isGameOver)
        {
            Time.timeScale = 0; // Stop the game
            gameOverPanel.SetActive(true); // Show Game Over Panel

            // Allow restart
            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Scenes/Level"); // Load scene
                Debug.Log("Restarting");
            }
        }

        // Check if Level Complete
        if(isLevelComplete)
        {
            Time.timeScale = 0; // Stop the game
            levelCompletePanel.SetActive(true); // Show Game Over Panel

            // Allow restart
            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Scenes/Level"); // Load scene
                Debug.Log("Next level");
            }
        }
    }
}

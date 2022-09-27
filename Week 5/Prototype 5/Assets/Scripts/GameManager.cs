using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables
    public List<GameObject>targets; // Holds the target objects to be spawned
    public float spawnRate = 2.0f; // Time for spawning targets i.e. coroutine delay
    private int score; // Holds the score of the player
    public bool isGameActive; // Holds game status i.e. Active (true) or Over (false)
    
    // UI Elements
    public TextMeshProUGUI scoreText; // Holds the score GUI element
    public TextMeshProUGUI gameOverText; // Holds the Game Over GUI element
    public Button restartButton; // Holds the restart button UI element
    public GameObject titleScreen; // Holds a reference to the Title Screen objects
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawning targets
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate); // Wait for defined no of seconds
            int index = Random.Range(0, targets.Count); // Randomly select a target from the list

            Instantiate(targets[index]); // Spawn randomly selected target
        }
    }

    // Keeping score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd; // Add to the score
        scoreText.text = "Score: " + score; // Displays the score
    }

    /* GAME STATES */
    // Start Game
    public void StartGame(int difficulty)
    {
        isGameActive = true; // Setting game to active status
        score = 0; // Initialising the score
        titleScreen.gameObject.SetActive(false); // Disabling the Title Screen objects
        spawnRate /= difficulty; // Divide the spawn rate by the difficulty, thus making the game harder

        StartCoroutine(SpawnTarget()); // Calls the spawning coroutine
        UpdateScore(0); // Initialising the score method    
    }


    // Game Over
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true); // Display Game Over text
        restartButton.gameObject.SetActive(true); // Display the Restart button
        isGameActive = false; // Set bool to false to end game
    }

    // Restart Game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene by getting its name and loading it
    }
}

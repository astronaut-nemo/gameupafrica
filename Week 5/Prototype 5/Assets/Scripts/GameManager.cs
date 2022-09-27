using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Variables
    public List<GameObject>targets; // Holds the target objects to be spawned
    public float spawnRate = 2.0f; // Time for spawning targets i.e. coroutine delay
    private int score; // Holds the score of the player
    public TextMeshProUGUI scoreText; // Holds the score GUI element
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget()); // Calls the spawning coroutine

        // Score keeping
        score = 0; // Initialising the score
        UpdateScore(0); // Initialising the score
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawning targets
    IEnumerator SpawnTarget()
    {
        while(true)
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
}

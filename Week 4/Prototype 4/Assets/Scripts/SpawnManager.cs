using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    private float spawnRange = 9.0f; // Holds the range for spawning
    public int enemyCount; // Holds the number of enemies
    public int waveNumber = 1; // Holds the current wave number

    // References
    public GameObject enemyPrefab; // Holds reference to the enemy Prefab
    public GameObject powerupPrefab; // Holds reference to the powerup Prefab
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber); // Spawn first wave
        SpawnPowerup(); // Spawn first powerup
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // Get the number of objects that have the 'Enemy.cs' script attached

        if(enemyCount == 0)
        {
            waveNumber++; // Increment the waveNumber
            SpawnEnemyWave(waveNumber); // Spawn 'waveNumber' amount of new enemies when there are no enemies left
            SpawnPowerup(); // Spawn powerups with each new enemy wave
        }
    }

    // Spawns enemy waves of size 'enemiesToSpawn'
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
        // Spawning the game object
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); // Create an instance of the enemy Prefab
        }
    }

    // Spawns power ups
    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // Create an instance of the powerup Prefab
    }

    // Generates a random spawn position
    private Vector3 GenerateSpawnPosition()
    {
        // Randomising the spawn position
        float spawnPosX = Random.Range(-spawnRange, spawnRange); // Randomising x-coordinate
        float spawnPosZ = Random.Range(-spawnRange, spawnRange); // Randomising z-coordinate

        Vector3 randomPos = new Vector3(spawnPosX, 0 , spawnPosZ); // Random position for spawning

        return randomPos; // Returning the random spawn position
    }
}

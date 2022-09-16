using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    private float spawnRange = 9.0f; // Holds the range for spawning
    public int enemyCount; // Holds the number of enemies

    // References
    public GameObject enemyPrefab; // Holds reference to the enemy Prefab
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(3);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // Get the number of objects that have the 'Enemy.cs' script attached

        if(enemyCount == 0)
        {
            SpawnEnemyWave(1); // Spawn one new enemy when there are no enemies left
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

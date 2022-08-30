using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    public GameObject[] animalPrefabs; // Array for holding the animal game objects
    private float spawnRangeX = 10.0f; // Range for horizontal posiiton of spawning
    private float spawnPosZ = 20.0f; // Coordinate for spawning along z-axis (constant)
    private float startDelay = 2.0f; // Delay before spawning starts
    private float spawnInterval = 1.5f; // Interval between spawning new animals

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval); // Calls the SpawnRandomAnimal(), 'startDelay' seconds after the game starts, every 'spawnInterval' seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // SpawnRandomAnimal is a method that spawns random animals from teh array that holds the animal Prefabs (like the name says ( ˙▿˙ ) )
    void SpawnRandomAnimal()
    {
        // Local variables
        int animalIndex = Random.Range(0, animalPrefabs.Length); // Randomly select an index (animal Prefab/type) in the array
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); // Randomise the horizontal position within the range of X, but at the same Z coordinate

        // Clone a random animal from the array
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}

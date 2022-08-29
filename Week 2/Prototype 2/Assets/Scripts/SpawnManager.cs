using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    public GameObject[] animalPrefabs;// Array for holding the animal game objects
    private float spawnRangeX = 10.0f;// Range for horizontal posiiton of spawning
    private float spawnPosZ = 20.0f;// Coordinate for spawning along z-axis

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Local variables
        int animalIndex = Random.Range(0, animalPrefabs.Length); // Randomly select an index in the array
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); // Randomise the horizontanl position within the range

        // When the 'S' key is pressed, spawn an animal
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
    }
}

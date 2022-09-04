using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script spawns in new obstacles */

public class SpawnManager : MonoBehaviour
{
    // Variables
    public GameObject obstaclePrefab; // Holds reference to Prefab to spawn
    private Vector3 spawnPosX = new Vector3(25, 0, 0); // Position to spawn
    private float startDelay = 2.0f; // Time at which the invoke starts
    private float spawnRate = 2.0f; // Interval at which the invoke repeats

    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("SpawnObstacle", startDelay, spawnRate); // Repeatedly call the SpawnObstacle method
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to instantiate obstacles
    void SpawnObstacle()
    {
         Instantiate(obstaclePrefab, spawnPosX, obstaclePrefab.transform.rotation); // Spawn obstacles at the given position with the given rotation
    }
}

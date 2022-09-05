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
    private PlayerController playerControllerScript; // Holds reference to the PlayerController.cs

    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("SpawnObstacle", startDelay, spawnRate); // Repeatedly call the SpawnObstacle method
       // Assign the playerControllerScript to the PlayerController.cs component on the "Player" object in the Hierarchy
       playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to instantiate obstacles
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            // If the gameOver bool is false, then spawn obstacles
            Instantiate(obstaclePrefab, spawnPosX, obstaclePrefab.transform.rotation); // Spawn obstacles at the given position with the given rotation
        }
    }
}

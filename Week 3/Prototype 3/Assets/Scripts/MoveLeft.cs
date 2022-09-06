using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script moves objects to the left */

public class MoveLeft : MonoBehaviour
{
    // Variables
    private float speed = 20; // Holds the value for the speed of movement
    private PlayerController playerControllerScript; // Holds reference to the PlayerController.cs
    private float leftBound = -15; // Holds left boundary limit
    
    // Start is called before the first frame update
    void Start()
    {
        // Assign the playerControllerScript to the PlayerController.cs component on the "Player" object in the Hierarchy
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // If the gameOver bool is false (the game is NOT over), then move the objects to the left
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left *Time.deltaTime * speed); // Move along x-axis with speed m/s
        }
        
        // If the object moves out of bounds and is an obstacle, then destroy it
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

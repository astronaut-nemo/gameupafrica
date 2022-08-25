using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public float horizontalInput; // Holds player input
    public float speed = 10.0f; // Determines speed of player movement
    public float xRange = 10.0f; // Determines range of bounds
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player controls movement of player game object
        horizontalInput = Input.GetAxis("Horizontal"); // Get player input for left-right movement
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        // Keeps the player within the bounds of the screen
        // Placed after the input method to get rid of jittering
        if (transform.position.x < -xRange) // Prevent player from leaving on screen left
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange) // Prevent player frmo leaving on screen right
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}

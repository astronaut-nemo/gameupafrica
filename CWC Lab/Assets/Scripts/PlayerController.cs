using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public float moveForce; // How fast the player moves
    public float zBound; // Bpundary on z-axis
    public float xBound; // Boundary on x-axis
    
    
    // References to gameobjects
    private Rigidbody playerRb; // Holds reference to the rigid body of the player

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Assign var playerRb to the player's Rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();      
    }

    /* Player movement LOOK INTO BETTER (MORE PRECISE, STOPS WHEN NOT MOVING) PLAYER CONTROL */
    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical"); // Controls movement along z-axis (forward-backward)
        float horizontalInput = Input.GetAxis("Horizontal"); // Player input that controls movement along the x-axis (left-right)

        playerRb.AddForce(Vector3.forward * moveForce * verticalInput); // Move in vertical direction based on player input
        playerRb.AddForce(Vector3.right * moveForce * horizontalInput); // Move force in horizontal direction on player input
    }

    /* Constrain player movement */
    void ConstrainPlayerPosition()
    {
        // Boundary on screen right-left
        if(transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z); // Boundary for screen right-left
        }
        if(transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z); // Boundary for screen right-left
        }

        // Boundary on screen forward-backward
        if(transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound); // Boundary for screen forward-backward
        }
        if(transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound); // Boundary for screen forward-backward
        }
    }
}

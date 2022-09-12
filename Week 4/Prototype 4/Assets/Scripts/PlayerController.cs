using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    private float speed = 8.0f; // Speed of movement
    public bool hasPowerUp = false; // TO check if player has collided with the powerup

    // References
    private Rigidbody playerRb; // Holds reference to gameobject Rigidbody
    private GameObject focalPoint; // Holds reference to the GameObject "Focal Point"
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Assign playerRb to gameobject Rigidbody
        focalPoint = GameObject.Find("Focal Point"); // Assign focalPoint to GameObject "Focal Point"
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical"); // Assigns the var forwardInput to player's input on the z-axis (up down arrows)
        
        // Apply force to playerRb in the direction of the forward axis of "Focal Point" that is controlled by forwardInput at the speed speed
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    // Checking for collision between player and powerup, and destorying the powerup
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true; // Set powerup bool to true
            Destroy(other.gameObject); // Destroy the powerup
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private float jumpForce = 12; // Holds multiplier for the jumping force on Player
    private float gravityMultiplier = 2; // Multiplier to vary gravity
    private float laneSwitch = 3; // Holds value for switching lanes
    private float laneBound = 2;

    public bool isOnGround = true;

    // References
    private Rigidbody playerRb; // Holds reference to the player's Rigidbody component

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>(); // Assign Player object Rb to playerRb
        Physics.gravity *= gravityMultiplier; // Changes in-game physics to the value we want
    }

    // Update is called once per frame
    void Update()
    {
        // If the up Key is pressed and the player is on the ground, make the Player jump by applying a force to its Rb
        if(Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && isOnGround && transform.position.x < laneBound)
        {
            transform.position = new Vector3(transform.position.x + laneSwitch, transform.position.y, transform.position.z);
            Debug.Log("Moving left");
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && isOnGround && transform.position.x > -laneBound)
        {
            transform.position = new Vector3(transform.position.x - laneSwitch, transform.position.y, transform.position.z);
            Debug.Log("Moving right");
        }
        
    }

    // Collisions Checker
    private void OnCollisionEnter(Collision collision)
    {
        // If Player is colliding with the ground, set bool to true
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}

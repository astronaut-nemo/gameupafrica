using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public float jumpForce = 12; // Holds multiplier for the jumping force on Player
    private float gravityMultiplier = 2; // Multiplier to vary gravity

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

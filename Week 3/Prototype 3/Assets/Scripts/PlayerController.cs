using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script allows the player to control the player object */

public class PlayerController : MonoBehaviour
{
    //Variables
    private Rigidbody playerRb; // Holds the Rigidbody of the player
    public float jumpForce; // How strong is the jump/distance of the jump
    public float gravityModifier; // Allows us to change the value of gravity as we please
    public bool isOnGround = true; // Check if player is on the ground
    public bool gameOver = false; // Check if player collides with obstacle thus the game is over
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Assign playerRb to the object's Rigidbody component
        Physics.gravity *= gravityModifier; // Changes in-game physics to the value we want
        playerAnim = GetComponent<Animator>(); // Assign playerAnim to the object's Animator component
    }

    // Update is called once per frame
    void Update()
    {
        // Player can only jump when touching the ground and gameOver is false (the game is NOT over)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Applies an instant force to the game object
            isOnGround = false; // The player is not on the ground while jumping
            playerAnim.SetTrigger("Jump_trig"); // Sets the Jump_trig Animator parameter
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Whenever the player collides with "Ground" game object, in this case the ground, set isOnGround boolean to true
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Whenever the player collides with "Obstacle" game object, in this case the ground, set gameOver boolean to true
            gameOver = true;
            Debug.Log("Game Over!"); // Print Game Over message
            playerAnim.SetBool("Death_b", true); // Set the death animation
            playerAnim.SetInteger("DeathType_int", 1); // Set the death animation type to Death_01
        }
        
    }
}

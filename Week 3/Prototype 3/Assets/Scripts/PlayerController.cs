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

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Assign playerRb to the object's Rigid body component
        Physics.gravity *= gravityModifier; // Changes in-game physics to the value we want
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) // Player can only jump when touching the ground
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Applies an instant force to the game object
            isOnGround = false; // The player is not on the ground while jumping
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Whenever the player collides with something, in this case the ground, set isOnGround boolean to true
        isOnGround = true;
    }
}

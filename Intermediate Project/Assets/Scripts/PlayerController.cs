using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private int jumpForce = 10; // Holds multiplier for the jumping force on Player
    private float gravityMultiplier = 2; // Multiplier to vary gravity

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
        // If the up Key is pressed, make the Player jump by applying a force to its Rb
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

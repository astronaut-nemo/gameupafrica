using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script allows the player to control the player object */

public class PlayerController : MonoBehaviour
{
    //Variables
    private Rigidbody playerRb; // Holds the Rigidbody of the player
    private Animator playerAnim; // Holds the Animator of the player
    public ParticleSystem explosionParticle; // Holds the explosions fx
    public ParticleSystem dirtParticle; // Holds the dirt splatter fx

    private AudioSource playerAudio; // Holds the AudioSource of the player
    public AudioClip jumpSound; // Holds the jumping sound clip
    public AudioClip crashSound; // Holds the crash sound clip

    public float jumpForce; // How strong is the jump/distance of the jump
    public float gravityModifier; // Allows us to change the value of gravity as we please
    
    public bool isOnGround = true; // Check if player is on the ground
    public bool gameOver = false; // Check if player collides with obstacle thus the game is over
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Assign playerRb to the object's Rigidbody component
        Physics.gravity *= gravityModifier; // Changes in-game physics to the value we want
        playerAnim = GetComponent<Animator>(); // Assign playerAnim to the object's Animator component
        playerAudio = GetComponent<AudioSource>(); // Assign playerAudio to the objects's AudioSource component
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
            dirtParticle.Stop(); // Don't play the dirt particle when in the air
            playerAudio.PlayOneShot(jumpSound, 1.0f); // Play jumpSound
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Whenever the player collides with "Ground" game object, in this case the ground, set isOnGround boolean to true + play dirt particle
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            /* Whenever the player collides with "Obstacle" game object, in this case the ground, set gameOver boolean to true + play death animation
                + play explosion particle + stop dirt particle
            */
            gameOver = true;
            Debug.Log("Game Over!"); // Print Game Over message
            playerAnim.SetBool("Death_b", true); // Set the death animation
            playerAnim.SetInteger("DeathType_int", 1); // Set the death animation type to Death_01
            explosionParticle.Play(); // Play the explosion particle system
            dirtParticle.Stop(); // Don't play the dirt particle when dead
            playerAudio.PlayOneShot(crashSound, 1.0f); // Play crashSound
        }
        
    }
}

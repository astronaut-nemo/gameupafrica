using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    // Variables
    public bool gameOver;
    public bool isLowEnough = true;

    public float upperLimit = 14;
    public float floatForce;
    public float bounceForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    // Particle Systems
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    // Audio
    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound; // When the player hits the ground or sky


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>(); // Assign playerRb to object's rigid body

    }

    // Update is called once per frame
    void Update()
    {
        // if player is low enough i.e. hasn't floated into the sky
        if (transform.position.y < upperLimit)
        {
            isLowEnough = true;
        }
        else {isLowEnough = false;}

        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && isLowEnough == true && !gameOver)
        {
            // Apply a small upward force at the start of the game
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        // if player collides with ground and the game is not over, bounce
        else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerAudio.PlayOneShot(bounceSound, 1.0f);
            playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse); // Move the balloon up when it hits the ground

        }
    }

}

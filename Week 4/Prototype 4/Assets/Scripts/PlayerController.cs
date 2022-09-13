using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    private float speed = 5.0f; // Speed of movement
    public bool hasPowerUp = false; // To check if player has collided with the powerup
    private float powerUpStrength = 15.0f; // Strength of yeeting enemy on collision

    // References
    private Rigidbody playerRb; // Holds reference to gameobject Rigidbody
    private GameObject focalPoint; // Holds reference to the GameObject "Focal Point"
    public GameObject powerupIndicator; // Holds powerup indicator
    
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

        // Powerup indicator to follow player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    // Checking for collision between player and powerup, and destorying the powerup
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true; // Set powerup bool to true
            powerupIndicator.gameObject.SetActive(true); // Activate the powerup indicator

            Destroy(other.gameObject); // Destroy the powerup object
            StartCoroutine(PowerUpCountdownRoutine()); // Start powerup countdown coroutine
        }
    }

    // PowerUp Countdown Timer Corroutine
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7); // Wait 7 seconds after powerup is activated
        hasPowerUp = false; // Deactivate the powerup
        powerupIndicator.gameObject.SetActive(false); // Deactivate the powerup indicator
    }


    // Checking for collision between player and enemy, while the player has a powerup. If conditions are met, yeet enemy away from player.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>(); // Get enemy's Rigidbody component and assign it to the var enemyRigidbody
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position; // Get vector in the direction to move the enemy away from the player

            // Move the eneny away from teh player with an Impulse force
            enemyRigidbody.AddForce(awayFromPlayer *powerUpStrength, ForceMode.Impulse);
            // Notification that player has  powerup and collided with the enemy
            Debug.Log("Collided with: " + collision.gameObject.name + " with the powerup set to " + hasPowerUp);
        }
    }
}

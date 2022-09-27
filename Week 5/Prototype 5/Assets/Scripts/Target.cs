using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Variables
    private float minSpeed = 12; // Minimum speed of upward force
    private float maxSpeed = 16; // Maximum speed of upward force
    private float maxTorque = 10; // Range for the torque 
    private float xRange = 4; // Range for the x-position
    private float ySpawnPos = -2; // Position to spawn along y-axis (below the background)
    public int pointValue; // Holds the value of each target
    public ParticleSystem explosionParticle; // Holds the explosion FX

    // References
    private Rigidbody targetRb; // Holds reference to the object's Rigidbody component
    private GameManager gameManager; // Holds reference to the "Game Manager" object
    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>(); // Assigns the object's Rigidbody to the variable targetRb
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Find the Game Manger object in the Hierarchy and get its GameManager.cs script, THEN assign it to the variable gameManager


        // Apply a random instantaneous force to the Rigidbody
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        
        // Apply a random spin/torque to the Rigidbody
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        // Randomise the object's position on x-axis, fixed y-axis below background and no change on the z-axis (z = 0)
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* FORCE, TORQUE, AND POSITION */
    // Generate random force vector
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Generate random torque float
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Generate random position vector
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    /* DESTROY TARGETS */
    // Destroy object when it is clicked on by the mouse
    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); // Instantiate the explosion particle at the position of the target with the rotation of the particle
        gameManager.UpdateScore(pointValue); // Change score by amount pointValue everytime an target is clicked on
    }

    // Destroy object when it falls onto the sensor i.e. below the screen
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script controls the behaviour of the player ball */

public class Player : MonoBehaviour
{
    // Variables
    public float bounceForce = 6; // Holds force to bounce player object

    // References
    public Rigidbody playerRb; // Holds reference to player Rigidbody component


    private void OnCollisionEnter(Collision collision)
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z); // Give the player a force to bounce in y-direction

    }
}

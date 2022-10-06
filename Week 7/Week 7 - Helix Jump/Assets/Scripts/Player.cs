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
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name; // Save the name of the collision material in a string

        if(materialName == "Safe (Instance)")
        {
            // Ball hits safe area

            Debug.Log("Safe!");
        }
        else if(materialName == "Bad (Instance)")
        {
            // Ball hits unsafe area
            GameManager.isGameOver = true; // End the game
            Debug.Log("Game Over!");
        }
        else if(materialName == "Last Ring (Instance)")
        {
            // Ball hits last ring
            GameManager.isLevelComplete = true; // Completed the level
            Debug.Log("Game Complete!");
        }
    }
}

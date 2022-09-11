using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables
    public float speed;
    
    // References
    private Rigidbody enemyRb; // Holds reference to gameobject Rigidbody
    private GameObject player; // Holds reference to Game Object "Player"
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>(); // Assign variabale enemyRb to gameobject Rigidbody
        player = GameObject.Find("Player"); // Assign variable player to Game Object "Player"
    }

    // Update is called once per frame
    void Update()
    {
        // Calculating the difference between player position and enemy position, then normalizing the vector
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        
        // Apply force on enemy to follow player
        enemyRb.AddForce(lookDirection * speed);
    }
}

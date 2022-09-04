using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script moves objects to the left */

public class MoveLeft : MonoBehaviour
{
    // Variables
    private float speed = 20; // Holds the value for the speed of movement
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left *Time.deltaTime * speed); // Move along x-axis with speed m/s
    }
}

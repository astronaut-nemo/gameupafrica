using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script controls the movement of the background sprite */

public class RepeatBackground : MonoBehaviour
{
    //Variables
    private Vector3 startPos; // Holds the starting position of the background
    private float repeatWidth; // Offset at which to repeat
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Assigning the initial (starting) position of the background to the startPos variable
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Assign half the width of the bg BoxCollider to the repeatWidth variable
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            // If the current x-position of bg is offset from the initial x-position, then reset to intial position
            transform.position = startPos; // Reset bg
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; /* As we are creating a component in Unity */

public class PlayerController : MonoBehaviour /* All Unity scripts inherit from MonoBehaviour */
{
    // Variables
    /* The object speed will be set to these decimal numbers and we can change the value from here */
    private float speed = 15.0f; // Sets the forward-backward speed
    private float turnSpeed = 25.0f; // Sets the rotation/turning speed

    /* Player Control*/
    private float horizontalInput; // Holds player input for turning movement
    private float forwardInput; // Holds player input for forward-backward movement

    // Start is called before the first frame update.
    void Start()
    {
        
    }

    void Update()
    {
        /*
        Update is called once per frame, thus it will depend on the fps of the player's device.
        Hence to edit the speed, we use a method (multiplying by time) that uses seconds instead of frames.

        Use Delta time to know how much time has elapsed between frames and multiply by a number (speed) to increase the speed of movement.
        Vector3 has (x, y, z) and by multiplying each value by Time (seconds) and speed (metres), we get object speed in m/s.
        */
        
        // Moving the vehicle forward here
        horizontalInput = Input.GetAxis("Horizontal"); // Get input on horizontal axis keys
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Turning the vehicle here
        forwardInput = Input.GetAxis("Vertical"); // Get input on vertical axis
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}

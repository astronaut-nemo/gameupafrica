using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; /* As we are creating a component in Unity */

public class PlayerController : MonoBehaviour /* All Unity scripts inherit from MonoBehaviour */
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
        Update is called once per frame, thus it will depend on the fps of the player's device
        Hence to edit the speed, we use a method that uses seconds instead of frames
    */
    void Update()
    {
        // We will move the vehicle forward here
        transform.Translate(Vector3.forward * Time.deltaTime * 20);
        /*
            Use Delta time to know how much time has elapsed and multiply by a number (20) to increase the speed to ~20m/s
            Vector3.forward has (0, 0, 1) and by multiplying each value by Time (seconds) and 20 (metres) to get to m/s
        */

    }
}

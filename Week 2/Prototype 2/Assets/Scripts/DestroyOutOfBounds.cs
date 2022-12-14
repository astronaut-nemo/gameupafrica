using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30; // Boundary at the top of the screen
    public float bottomBound = -10; // Boundary at the bottom of the screen
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Delete objects offscreen
        if (transform.position.z > topBound) // Boundary at the top of the screen
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomBound) // Boundary at the bottom of the screen
        {
             Destroy(gameObject);
             Debug.Log("Game Over!");
        }
        
        /* Alternatively, without the debug log:
        if (transform.position.z > topBound || transform.position.z < bottomBound)
        {
            Destroy(gameObject);
        }*/

    }
}

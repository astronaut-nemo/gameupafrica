using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCenter : MonoBehaviour
{
    private int spinSpeed = 200; // Initialised spin speed variable
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates the propeller about the z-axis
        transform.Rotate(Vector3.forward, Time.deltaTime * spinSpeed);
    }
}

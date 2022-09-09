using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Variables
    public float rotationSpeed; // Sets the speed of camera rotation
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Assigns the var horizontalInput to the player's input (left-right arrows)
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * horizontalInput); // Rotate by the rotation speed for the player's input
    }
}

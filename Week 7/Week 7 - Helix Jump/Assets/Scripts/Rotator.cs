using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script allows the player to rotate the toower*/

public class Rotator : MonoBehaviour
{
    // Variables
    public float rotationSpeed = 150; // Speed of rotation of the tower
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Hide the cursor
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) // 0 = left mouse button index
        {
            float mouseX = Input.GetAxisRaw("Mouse X"); // Get the input from the mouse in the x-axis without filtering
            float yRotation = mouseX * rotationSpeed * Time.deltaTime; // Get the speed/frce of rotation about y-axis
            
            transform.Rotate(0, -yRotation, 0); // Rotate object about y-axis
        }
    }
}

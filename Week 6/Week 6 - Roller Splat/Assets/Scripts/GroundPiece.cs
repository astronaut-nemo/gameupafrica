using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPiece : MonoBehaviour
{
    // Only changes the colour of the ground as the ball roll over it
    public bool isColoured = false; // Holds state of ground piece

    // Changes the colour of the ground piece based on the colour passed to the meethod
    public void ChangeColour(Color colour)
    {
        GetComponent<MeshRenderer>().material.color = colour; // Change the colour of Mesh Renderer to the specific colour
        isColoured = true; // After the colour is changed, set isColoured to true
        
        FindObjectOfType<GameManager>().CheckComplete(); // CHeck if level is complete
    }
}

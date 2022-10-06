using UnityEngine;

/* This script allows the camera to follow the player */

public class FollowPlayer : MonoBehaviour
{
    // Variables
    private Vector3 offset; // Offset between player and camera
    public int offsetMultiplier = 21; // Multiplier to move camera back
    public float smoothSpeed = 0.04f; // Holds value for interpolation of camera position

    // References
    public Transform target; // Reference to the position of the player
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; // Camera position - target position
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition =Vector3.Lerp(target.position, target.position + offset*offsetMultiplier, smoothSpeed); // Interpolate a new position for the camera
        transform.position = newPosition; // Set camera position to newPosition
    }
}

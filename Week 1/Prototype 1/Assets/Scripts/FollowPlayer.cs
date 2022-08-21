using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    /* Get references of game objects to tie one object (camera) to another (vehicle/player object)
    for the first object to get references stored in the variable (player). */
    public GameObject player; // Public to allow an external object to access variable.
    private Vector3 offset = new Vector3(0, 6, -12); // Private as it is used only inside this class; removes hard coded value in transform

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() /* LateUpdate() updates after the Update() for the vehicle updates, so that it is butter smooth*/
    {
        /*
            Set the camera position to vehicle/player object position by referencing (equating it to) the player variable
            Offset the camera behind the player by adding to the player's position.
        */
        transform.position = player.transform.position + offset; 
    }
}

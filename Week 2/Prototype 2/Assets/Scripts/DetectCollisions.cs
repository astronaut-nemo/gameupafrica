using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detecting collisions between objects and destroying those objects
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Destroys this Game Object
        Destroy(other.gameObject); // Destroys the other Game Object
    }
}

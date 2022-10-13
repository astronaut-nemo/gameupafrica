using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    // Variables
    public float speed = 5.0f; // Holds the speed of the object
    public float outofBound = 10.0f; // Holds the limit at which objects are destroyed off screen


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed); // Move the object along the z-axis
        DestroyOutOfBounds();
    }

    
    // Destroy objects tagged Ground, Treat or Obstacle once they move out of range
    private void DestroyOutOfBounds()
    {
        if(transform.position.z < -outofBound)
        {
            if(gameObject.CompareTag("Ground") || gameObject.CompareTag("Treat") || gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    // Variables
    public float speed = 5.0f; // Holds the speed of the object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed); // Move the object along the z-axis
    }

    // Destroy objects once they move out of range
    private void DestroyOutOfBounds()
    {

    }
}

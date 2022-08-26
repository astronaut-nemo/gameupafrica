using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30;
    public float bottomBound = -10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Delete objects offscreen
        if (transform.position.z > topBound || transform.position.z < bottomBound)
        {
            Destroy(gameObject);
        }
    }
}

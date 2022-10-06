using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    // Variables
    public float ySpawn = 0; // Distance to spawn rings
    public float ringDistance = 5; // Difference in ySpawn position
    public int numberOfRings = 7; // Number of helix rings to spawn

    // References
    public GameObject[] helixRings; // Array to hold helix rings
    public GameObject lastRing; // Reference to Last Ring object

    // Start is called before the first frame update
    void Start()
    {
        // Spawn First Ring
        SpawnRing(0);

        // Spawn the desired number of rings
        for(int i = 0; i < numberOfRings; i++)
        {
            SpawnRing(Random.Range(1, helixRings.Length - 1));
        }

        // Spawn Last Ring
        SpawnRing(helixRings.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawns helix rings
    public void SpawnRing(int ringIndex)
    {
        GameObject ringInstant = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity); // Spawn a helix ring from the array
        ringInstant.transform.parent = transform; // Add the rings to the Helix Manager object
        ySpawn -= ringDistance; // Decrease ySpawn by ringDistance
    }
}

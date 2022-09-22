using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    public List<GameObject>targets; // Holds the target objects to be spawned
    public float spawnRate = 1.0f; // Time for spawning targets i.e. coroutine delay
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget()); // Calls the spawning coroutine
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate); // Wait for defined no of seconds
            int index = Random.Range(0, targets.Count); // Randomly select a target from the list

            Instantiate(targets[index]); // Spawn randomly selected target
        }
    }
}

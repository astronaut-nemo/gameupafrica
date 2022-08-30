using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float cooldown;

    // Update is called once per frame
    void Update()
    {
        // Cooldown timer to count 1 second
        cooldown += Time.deltaTime;
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && cooldown > 0.3f)
        {
            Invoke("SpawnDog", 0);
        }
    }

    // Method for spawning a dog
    void SpawnDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        cooldown = 0;
    }
}

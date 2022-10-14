using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject[] itemPrefab; // Array that holds reference to the obstacle Prefab
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", 3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnItem()
    {
        int index = Random.Range(0, itemPrefab.Length); // Spawn a random obstacle in the array
        Instantiate(itemPrefab[index], itemPrefab[index].transform.position, itemPrefab[index].transform.rotation);
    }
}

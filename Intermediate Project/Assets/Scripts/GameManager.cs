using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject[] groundPiecePrefab; // Array that holds reference to the ground piece Prefab
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnGroundPiece", 2.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnGroundPiece()
    {
        int index = Random.Range(0, groundPiecePrefab.Length);
        Instantiate(groundPiecePrefab[index], groundPiecePrefab[index].transform.position, groundPiecePrefab[index].transform.rotation);
    }
}

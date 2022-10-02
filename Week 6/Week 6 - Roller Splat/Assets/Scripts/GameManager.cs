using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The Game Manager takes care of the game state, scores, level loading etc 
    We only want one Game Manager that wil survive swapping scenes and be in all levels,
    hence we use
*/

public class GameManager : MonoBehaviour
{
    public static GameManager singleton; // Object that only exists once and is always active in this case

    // Set up level
    private GroundPiece[] allGroundPieces; // Array to hold all the ground piece objects
    
    // Start is called before the first frame update
    void Start()
    {
        SetUpNewLevels();   
    }

    private void SetUpNewLevels()
    {
        allGroundPieces = FindObjectsOfType<GroundPiece>(); // Looks for all the ground tiles in the level and store them in array
    }
}

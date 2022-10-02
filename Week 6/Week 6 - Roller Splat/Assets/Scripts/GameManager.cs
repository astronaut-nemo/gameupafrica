using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this; // This instance of the Game Manager will be the singleton
        }
        else if(singleton != this) // If there already is another, destroy this object
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        // As soon as the GM is enable, set an event
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }


    /* Create a new level */
    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetUpNewLevels();
    }

    public void CheckComplete()
    {
        bool isFinished = true; // Check if level is complete

        for(int i = 0; i < allGroundPieces.Length; i++) // Check if all ground pieces are coloured
        {
            if(allGroundPieces[i].isColoured == false) // If one of the ground pieces is not coloured...
            {
                isFinished = false; // Keep as false
                break; // Keep running for-loop
            }
        }

        if(isFinished)
        {
            /* Load next level*/
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            // Go back to first level if final level complete
            SceneManager.LoadScene(0);
        }
        else
        {
            // Load next scene in index
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Increase the index of the scene by 1 to get the next scene to load
        }
    }
}

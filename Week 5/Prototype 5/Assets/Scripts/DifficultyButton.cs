using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Variables
    public int difficulty; // Holds the value that determines the difficulty of the game based on the button clicked
    
    // References
    private Button button; // Holds reference to the object's Button component
    private GameManager gameManager; // Holds reference to the Game MAnager object in the Hierarchy

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); // Assign the object's Button component to the variable button
        button.onClick.AddListener(SetDifficulty); // Call SetDifficulty() when the button is pressed

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Find and assign the Game Manager object to the gameManager variable
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Setting difficulty
    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked"); // Indicated the button that was clicked
        gameManager.StartGame(difficulty); // Start the game
    }
}

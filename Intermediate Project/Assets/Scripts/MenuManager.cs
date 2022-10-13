using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    /* Load Main Menu Scene */
    public void LoadMainMenu()
    {
      SceneManager.LoadScene("Scenes/Main Menu");
    }

    /* Load the game Level Scene*/
    public void LoadLevel()
    {
      // Load Level Scene
      SceneManager.LoadScene("Scenes/Level");
    }

    /* Exiting the Game */
    public void QuitGame()
    {
      Debug.Log("Quit");
      Application.Quit(); // End the application
    }
}

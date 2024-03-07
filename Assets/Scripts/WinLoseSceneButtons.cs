§using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseSceneButtons : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// Loads the "Main" scene when the "Main Menu" button is clicked.
    /// </summary>
    public void LoadMainScene()
    {
        Debug.Log(gameObject.name + ": Main Menu Button clicked");
        SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// Loads the "CollatedScene" scene when the "Try again" button is clicked.
    /// </summary>
    public void LoadFirstLevel()
    {
        Debug.Log(gameObject.name + ": Try again Button clicked");
        SceneManager.LoadScene("CollatedScene");
    }

    /// <summary>
    /// Quits the application when the "Quit" button is clicked.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log(gameObject.name + ": Quit Button clicked");
        Application.Quit(); // Quits the application
        Debug.Log("Game is exiting");
    }
}

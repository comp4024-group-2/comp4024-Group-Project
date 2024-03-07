using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneButtons : MonoBehaviour
{
    /// <summary>
    /// Loads the "CollatedScene" scene upon activation (presumably when a button is pressed).
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene("CollatedScene");
        Debug.Log("Loading scene: CollatedScene"); // Log a message indicating scene loading
    }

    /// <summary>
    /// Quits the application when called.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit(); // Exits the application
        Debug.Log("Game is exiting"); // This log message might not be reached as Application.Quit usually stops execution
    }
}


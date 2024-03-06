using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseSceneButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("CollatedScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit(); // Quits the application
        Debug.Log("Game is exiting");
    }
}

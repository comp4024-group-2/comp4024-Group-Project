using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseSceneButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMainScene()
    {
        Debug.Log(gameObject + ": Main Menu Button clicked");
        SceneManager.LoadScene("Main");
    }

    public void LoadFirstLevel()
    {
        Debug.Log(gameObject + ": Try again Button clicked");
        SceneManager.LoadScene("CollatedScene");
    }

    public void QuitGame()
    {
        Debug.Log(gameObject + ": Quit Button clicked");
        Application.Quit(); // Quits the application
        Debug.Log("Game is exiting");
    }
}

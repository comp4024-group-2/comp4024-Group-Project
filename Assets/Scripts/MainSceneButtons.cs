using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainSceneButtons : MonoBehaviour
{
    public void LoadScene()
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


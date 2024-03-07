using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    GameManager gameManager;
    bool playerStarted = false;
    bool playerMoving = false;

    private void Awake()
    {
        // Find the GameManager object and get its component
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();
    }

    public void PlayButtonPressed()
    {
        // This button changes to a pause button after the user selects it,
        // so it has multiple uses
        Debug.Log("Play Button pressed");

        // Check if player hasn't started yet
        if (!playerStarted)
        {
            // Start the player, set flags, and change button text to "Pause"
            gameManager.StartPlayer();
            playerStarted = true;
            playerMoving = true;
            GameObject.Find("PlayButton").GetComponentInChildren<Text>().text = "Pause";
            
            return;
        }

        // Check if player is currently moving
        if (playerMoving)
        {
            // Pause the player, set flags, and change button text to "Resume"
            gameManager.PausePlayer();
            playerMoving = false;
            GameObject.Find("PlayButton").GetComponentInChildren<Text>().text = "Resume";
            return;
        }
        // Player is already paused, so resume and change button text to "Pause"
        gameManager.ResumePlayer();
        playerMoving = true;
        GameObject.Find("PlayButton").GetComponentInChildren<Text>().text = "Pause";
    }

    public void ResetButtonPressed()
    {
        // Reset the player and update flags and button text
        Debug.Log("Reset Button pressed");
        gameManager.ResetPlayer();
        playerStarted = false;
        playerMoving = false;
        GameObject.Find("PlayButton").GetComponentInChildren<Text>().text = "Play";

    }

    public void HomeButtonPressed()
    {
        // Load the "Main" scene
        Debug.Log("home Button pressed");
        SceneManager.LoadScene("Main");
    }

    public void RestartButtonPressed()
    {
        Debug.Log("Restart Button Pressed");
        // Call the GameManager's Restart function
        gameManager.Restart();

        //gameManager.Restart();
    }








}

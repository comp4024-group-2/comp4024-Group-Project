using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Main 2");
    }

    GameManager gameManager;
    bool playerStarted = false;
    bool playerMoving = false;

    private void Awake()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();
    }

    public void PlayButtonPressed()
    {
        // This button changes to a pause button after the user selects it,
        // so it has multiple uses
        Debug.Log("Play Button pressed");


        if (!playerStarted)
        {
            gameManager.StartPlayer();
            playerStarted = true;
            playerMoving = true;
            GameObject.Find("PlayButton").GetComponentInChildren<Text>().text = "Pause";
            
            return;
        }

        if (playerMoving)
        {
            gameManager.PausePlayer();
            playerMoving = false;
            GameObject.Find("PlayButton").GetComponentInChildren<Text>().text = "Resume";
            return;
        }

        gameManager.ResumePlayer();
        playerMoving = true;
        GameObject.Find("PlayButton").GetComponentInChildren<Text>().text = "Pause";
    }

    public void ResetButtonPressed()
    {
        Debug.Log("Reset Button pressed");
        gameManager.SetMoveVectorX(0);
    }

    public void RestartButtonPressed()
    {
        Debug.Log("Restart Button Pressed");
    }








}

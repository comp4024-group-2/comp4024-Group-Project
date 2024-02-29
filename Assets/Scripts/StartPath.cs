using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPath : MonoBehaviour
{

    public GameManager gameManager;
    public bool playing;

    

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("StartPath Awake called");
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();
        playing = false;

    }

    public void PlayButtonPressed()
    {
        Debug.Log("PlayButton Pressed");
        if (playing)
        {
            gameManager.SetMoveVectorX(0f);
            GameObject.Find("PlayButton").GetComponentInChildren<Text>().text = "Resume";
        }
        else
        {
            gameManager.SetMoveVectorX(1f);
            GameObject.Find("PlayButton").GetComponentInChildren<Text>().text = "Pause";
        }
        playing = !playing;

        

    }

    public void ResetPlayerPressed()
    {
        Debug.Log("Reset Button Pressed");

        //gameManager.SetMoveVectorX(0);
        gameManager.SetResetPlayer(true);
        gameManager.SetMoveVectorX(0);
        GameObject.Find("PlayButton").GetComponentInChildren<Text>().text = "Start";

        playing = false;
        

    }

    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        if (playing)
        {
            gameManager.SetMoveVectorX(0f);
        }
        else
        {
            gameManager.SetMoveVectorX(0.5f);
        }
        playing = !playing;
    }


}

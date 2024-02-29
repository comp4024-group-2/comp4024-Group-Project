using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        gameManager.SetMoveVectorX(1f);

    }

    public void PlayButtonPressed()
    {
        Debug.Log("PlayButton Pressed");
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

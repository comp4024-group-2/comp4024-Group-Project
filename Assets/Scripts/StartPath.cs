using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartPath : MonoBehaviour
{

    public GameManager gameManager;
    public bool playing;

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();
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

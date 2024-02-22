using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartPath : MonoBehaviour
{

    public gameManager GameManager;
    public bool playing;

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();
        playing = false;

    }

    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        if (playing)
        {
            GameManager.SetMoveVectorX(0f);
        }
        else
        {
            GameManager.SetMoveVectorX(0.5f);
        }
        playing = !playing;
    }


}

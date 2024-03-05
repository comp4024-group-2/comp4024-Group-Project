using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Main 2");
    }

    GameManager gameManager;

    private void Awake()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();
        gameManager.SetMoveVectorX(1);

    }

    public void StartPath()
    {
        gameManager.SetMoveVectorX(1);
    }


}

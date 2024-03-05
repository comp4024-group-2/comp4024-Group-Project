using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //PlayerMovement playerMovement;

    public float moveSpeed = 1.0f;
    public Vector2 moveVector;
    public bool playerMoving = false;
    public bool resetPlayer = false;

    public void SetMoveVectorX(float x)
    {
        moveVector = new Vector2(x, moveVector.y);
    }

    public void StartPlayer()
    {
        Debug.Log("StartPlayer()");
        playerMoving = true;
        SetMoveVectorX(1);
    }

    public void PausePlayer()
    {
        Debug.Log("PausePlayer()");
        playerMoving = false;
        SetMoveVectorX(0);
    }

    public void ResumePlayer()
    {
        Debug.Log("ResumePlayer()");
        playerMoving = true;
        SetMoveVectorX(1);
    }

    public void ResetPlayer()
    {

    }

}

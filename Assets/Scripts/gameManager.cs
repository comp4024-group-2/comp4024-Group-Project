using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public float moveSpeed = 1.0f;
    public Vector2 moveVector;

    public void SetMoveVectorX(float x)
    {
        moveVector = new Vector2(x, moveVector.y);
    }
}

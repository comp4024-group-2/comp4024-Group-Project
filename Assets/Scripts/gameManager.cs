using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public float moveSpeed = 1.0f;
    public Vector2 moveVector;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void SetMoveVectorX(float x)
    {
        moveVector = new Vector2(x, moveVector.y);
    }
}

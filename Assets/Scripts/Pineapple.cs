using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : MonoBehaviour
{

    Rigidbody2D body;
    public Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        startPos = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {

        body.SetRotation(body.rotation + 0.5f);

    }


    public void ResetPosition()
    {
        transform.position = startPos;
        body.velocity = new Vector2(0f, 0f);
    }

}

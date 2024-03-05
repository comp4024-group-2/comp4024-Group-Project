using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0;
    public float jump;
    public bool isJumping; // a bool means is it a true or false statement
    public float playersMove;
    public Rigidbody2D rb;
    Vector2 startPos;
    // Start is called before the first frame update

    public bool goingToJump = true;

    CodeBlockInstruction currentInstruction;

    GameManager gameManager;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // The rigid body 2d allows an object to have simulating physical interactions
        rb = GetComponent<Rigidbody2D>();

        startPos = transform.position;


        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();

        Debug.Log("Player start pos: " + startPos.x);

    }

    // Update is called once per frame
    public void Update()
    {

        if (gameManager.resetPlayer)
        {
            ResetPlayer();
            return;
        }

        if (!gameManager.playerMoving)
        {
            rb.Sleep();
            return;
        }



        rb.WakeUp();

        if (goingToJump)
        {


            // Important values (each x is an edge of a platform):

            // x1 = -6
            // x2 = -5
            // x3 = -4
            // x4 = -3.1
            // x5 = -1.7
            // x6 = -0.4
            // x7 = 0.8
            // x9 = 2.1

            float x1 = -6f;
            float x2 = -5f;
            float x3 = -4f;
            float x4 = -3.1f;
            float x5 = -1.7f;
            float x6 = -0.4f;
            float x7 = 0.8f;
            float x9 = 2.1f;


            if (transform.position.x < x2)
            {
                if (transform.position.x > x1)
                {
                    Debug.Log("JUMP NOW");
                    Jump(300f);
                    goingToJump = false;
                }
            }
            



            //if (startPos.x < transform.position.x && transform.position.x > -6)
            //{
            //    Debug.Log("JUMP NOW");
            //    Jump(200f);
            //    //goingToJump = false;
            //}

            //else if (-4.8 < transform.position.x && transform.position.x > -4)
            //{
            //    Debug.Log("JUMP NOW");
            //    Jump(100f);
            //    //goingToJump = false;
            //}
        }



        // this gets the arrow keys or Awsd keys to move the character left or right
        playersMove = Input.GetAxis("Horizontal");

        // this moves the character left or right depending on the input speed
        rb.velocity = new Vector2(speed /** gameManager.moveSpeed*/, rb.velocity.y);

        //rb.velocity = new Vector2(speed * rb.velocity.x, rb.velocity.y);

        // if the charcter is not jumping and the player is pressing the jump button
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            // this allows the character to jump
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            Debug.Log("Jump"); // example in how to leave debug statements
        }

        Debug.Log("Player current pos = " + transform.position.x);


    }

    public void MoveRight()
    {
        Debug.Log("Move Right");
        speed = 1;
        //rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void MoveLeft() {
        speed = -1;
    }

    //public void BigJump(float y)
    //{
    //    currentInstruction = CodeBlockInstruction.Big
    //    Jump(y);
    //}

    public void Jump(float y) {
        Debug.Log("Jump called");
        //currentInstruction = CodeBlockInstruction.
        if (isJumping == false)
        {
            Debug.Log("Character jumping speed = " + y);
            // this allows the character to jump
            rb.AddForce(new Vector2(rb.velocity.x, y));
            //isJumping == true;
        }
    }

    public void ResetPlayer()
    {
        Debug.Log("ResetPlayer()");
        resetRotation();
        speed = 0;
        transform.position = startPos;
        rb.Sleep();
        gameManager.resetPlayer = false;
        gameManager.playerMoving = false;
    }

    public void resetRotation()
    {
        Debug.Log("resetRotation");
        rb.SetRotation(0);
    }

    // this function checks if the user is on the ground if so then the charcter isnt jumping
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    // this function checks if the user is off the ground if so then the charcter is jumping
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}


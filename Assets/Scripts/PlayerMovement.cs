using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0;
    public float jump;
    public bool isJumping; // a bool means is it a true or false statement
    public bool isGrabLast = false;
    public float playersMove;
    public Rigidbody2D rb;
    public Vector2 startPos;
    // Start is called before the first frame update
    public bool goingToJump = false;
    public bool runningInstruction = false;
    public GameManager gameManager;
    public float jumpHeight;

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

        isJumping = true;
        runningInstruction = true;

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

        if (goingToJump && !isJumping)
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

            float x1 = -8f;
            float x2 = -6f;
            float x3 = -5f;
            float x4 = -4f;
            float x5 = -3.1f;
            float x6 = -1.7f;
            float x7 = -0.4f;
            float x8 = 0.8f;
            float x9 = 2.1f;



            if (speed < 0)
            {
                if (transform.position.x < x1)
                {
                    Jump();
                }
            }

            else if (speed == 0)
            {
                Jump();
            }
            else
            {
                if (transform.position.x < x3)
                {
                    if (transform.position.x > x2)
                    {
                        Debug.Log("JUMP NOW");
                        Jump();
                        goingToJump = false;
                    }
                }

                else if (transform.position.x < x5)
                {
                    if (transform.position.x > x4)
                    {
                        Debug.Log("JUMP NOW");
                        Jump();
                        goingToJump = false;
                    }
                }
                else if (transform.position.x < x7)
                {
                    if (transform.position.x > x6)
                    {
                        Debug.Log("JUMP NOW");
                        Jump();
                        goingToJump = false;
                    }
                }

                else if (transform.position.x < x9)
                {
                    if (transform.position.x > x8)
                    {
                        Debug.Log("JUMP NOW");
                        Jump();
                        goingToJump = false;
                    }
                }
            }
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

        //Debug.Log("Player current pos = " + transform.position.x);


    }

    public void IsItLastSlot(bool last)
    {
        Debug.Log("is the last slot grab- " + last);
        isGrabLast = last;
        runningInstruction = false;
    }

    public void MoveRight()
    {
        Debug.Log(gameObject + ": Move Right");
        speed = 1;
        runningInstruction = false;
        //rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void MoveLeft() {
        speed = -1;
        runningInstruction = false;
    }

    public void BigJump(float y)
    {
        goingToJump = true;
        runningInstruction = true;
        //Jump(y);
    }

    public void PrepareJump(float y)
    {
        Debug.Log("Prepare to jump");
        jumpHeight = y;
        goingToJump = true;
        runningInstruction = true;
    }

    public void Jump() {
        Debug.Log("Jump called");
        //currentInstruction = CodeBlockInstruction.
        if (isJumping == false)
        {
            Debug.Log("Character jumping speed = " + jumpHeight);
            // this allows the character to jump
            rb.AddForce(new Vector2(rb.velocity.x, jumpHeight));
            isJumping = true;
            goingToJump = false;
            
        }
    }

    public void ResetPlayer()
    {
        Debug.Log("ResetPlayer()");
        speed = 0;
        transform.position = startPos;
        resetRotation();
        rb.Sleep();

        goingToJump = false;
        isJumping = true;
        runningInstruction = true;

        gameManager.resetPlayer = false;
        gameManager.playerMoving = false;
    }

    public void resetRotation()
    {
        //Debug.Log("resetRotation");
        rb.SetRotation(1);
    }

    // this function checks if the user is on the ground if so then the charcter isnt jumping
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Debug.Log(collision.gameObject);

        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Player touch ground");
            isJumping = false;
            runningInstruction = false;
            resetRotation();
        }
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Debug.Log("Player Died");
            SceneManager.LoadScene("LoseScene");
        }
        if (collision.gameObject.CompareTag("Pineapple") && isGrabLast)
        {
            Debug.Log("Player Won!");
            SceneManager.LoadScene("WinScene");
        }
    }

    // this function checks if the user is off the ground if so then the charcter is jumping
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            runningInstruction = true;
        }
    }
}


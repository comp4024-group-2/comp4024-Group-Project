using System.Collections;
using System.Collections.Generic;
using Codice.CM.Client.Differences;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //PlayerMovement playerMovement;

    public float moveSpeed = 0;
    public Vector2 moveVector = new Vector2(1, 1);
    public bool playerMoving = false;
    public bool resetPlayer = false;
    public bool playerStarted = false;

    public PlayerMovement player;

    CodeBlockSlot[] codeBlockSlots;
    //CodeBlockInstruction[] codeBlockInstructions;
    DragDrop[] codeBlocks;

    Queue<DragDrop> codeBlockQueue;





    private void Awake()
    {
        Debug.Log(gameObject);
        GameObject.Find("BlockOrder_Panel");
        codeBlockSlots = GameObject.Find("BlockOrder_Panel").GetComponentsInChildren<CodeBlockSlot>();

        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        Debug.Log("Player Speed: " + player.speed);

    }

    public void SetMoveVectorX(float x)
    {
        moveVector = new Vector2(x, moveVector.y);
    }

    public void StartPlayer()
    {
        Debug.Log("StartPlayer()");
        playerMoving = true;
        playerStarted = true;
        //player.MoveRight();

        //codeBlocks = new List<DragDrop>();

        codeBlockQueue = new Queue<DragDrop>();


        foreach (CodeBlockSlot cbs in codeBlockSlots)
        {
            
            DragDrop codeBlock = cbs.GetComponentInChildren<DragDrop>();         

            if (codeBlock == null)
            {
                continue;
            }

            Debug.Log(codeBlock.gameObject);

            StartCoroutine(WaitActionCompleted(codeBlock));


            codeBlockQueue.Enqueue(codeBlock);

            
        }
    }

    IEnumerator WaitActionCompleted(DragDrop codeBlock)
    {
        Debug.Log("WaitActionCompleted started");

        while (player.runningInstruction)
        {
            yield return null;
        }

        Debug.Log("WaitActionCompleted complete");

        switch (codeBlock.codeBlockInstruction)
        {
            case CodeBlockInstruction.MoveRight:
                Debug.Log("Move Right");
                player.MoveRight();
                break;

            case CodeBlockInstruction.MoveLeft:
                Debug.Log("MoveLeft");
                player.MoveLeft();
                break;

            case CodeBlockInstruction.BigJump:
                Debug.Log("BigJump");
                //player.goingToJump = true;
                player.PrepareJump(400f);
                break;

            case CodeBlockInstruction.SmallJump:
                Debug.Log("SmallJumpt");
                //player.goingToJump = true;
                player.PrepareJump(200f);
                break;

            case CodeBlockInstruction.Grab:
                Debug.Log("Grab");
                break;

            default:
                Debug.Log("No instruction found");
                break;
        }

        
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
        Debug.Log("GameManager: ResetPlayer()");
        resetPlayer = true;
        playerMoving = false;
        playerStarted = false;
    }

    public void Restart()
    {
        //ResetPlayer();
        // ResetCodeBlocks();

        //foreach (CodeBlockSlot cbs in codeBlockSlots)
        //{
        //    Debug.Log(cbs.gameObject);
        //    Debug.Log(cbs.GetComponentInChildren<DragDrop>().codeBlockInstruction);

        //}

    }

}




public enum CodeBlockInstruction {

    MoveRight,
    MoveLeft,
    SmallJump,
    BigJump,
    Grab

}

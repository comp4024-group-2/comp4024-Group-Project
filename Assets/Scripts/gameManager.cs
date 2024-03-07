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
    public bool lastSlot = false;
    public PlayerMovement player;


    CodeBlockSlot[] codeBlockSlots;
    //CodeBlockInstruction[] codeBlockInstructions;
    DragDrop[] codeBlocks;

    Queue<DragDrop> codeBlockQueue;

    Pineapple pineapple;





    private void Awake()
    {
        Debug.Log(gameObject);
        GameObject.Find("BlockOrder_Panel");
        codeBlockSlots = GameObject.Find("BlockOrder_Panel").GetComponentsInChildren<CodeBlockSlot>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        Debug.Log("Player Speed: " + player.speed);
        pineapple = GameObject.Find("Pineapple").GetComponent<Pineapple>();
        Debug.Log(pineapple.startPos.x);
        

    }

    private void Start()
    {
        
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

            if (cbs.CompareTag("LastSlot"))
            {
                Debug.Log("last slot to true");
                lastSlot = true;
            }

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

        player.runningInstruction = true;

        Debug.Log("WaitActionCompleted complete");
        Debug.Log(codeBlock.codeBlockInstruction);

        switch (codeBlock.codeBlockInstruction)
        {
            case CodeBlockInstruction.MoveRight:
                Debug.Log(gameObject + ": Move Right");
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
                player.PrepareJump(320f);
                break;

            case CodeBlockInstruction.Grab:
                Debug.Log("grab fruit");
                player.IsItLastSlot(lastSlot);
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
        lastSlot = false;
        player.ResetPlayer();
        pineapple.ResetPosition();
        
    }

    public void Restart()
    {
        ResetPlayer();
        ResetCodeBlocks();

        //foreach (CodeBlockSlot cbs in codeBlockSlots)
        //{
        //    Debug.Log(cbs.gameObject);
        //    Debug.Log(cbs.GetComponentInChildren<DragDrop>().codeBlockInstruction);

        //}

    }

    public void ResetCodeBlocks()
    {
        foreach (CodeBlockSlot cbs in codeBlockSlots)
        {
            DragDrop codeBlock = cbs.GetComponentInChildren<DragDrop>();

            if (codeBlock == null)
            {
                continue;
            }

            codeBlock.ResetPosition();
        }
    }

}




public enum CodeBlockInstruction {

    MoveRight,
    MoveLeft,
    SmallJump,
    BigJump,
    Grab

}

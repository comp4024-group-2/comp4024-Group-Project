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

    CodeBlockSlot[] codeBlockSlots;
    //CodeBlockInstruction[] codeBlockInstructions;
    //DragDrop[] codeBlocks;

    private void Awake()
    {
        Debug.Log(gameObject);
        GameObject.Find("BlockOrder_Panel");
        codeBlockSlots = GameObject.Find("BlockOrder_Panel").GetComponentsInChildren<CodeBlockSlot>();

        foreach (CodeBlockSlot cbs in codeBlockSlots)
        {
            Debug.Log(cbs.gameObject);
        }


    }

    public void SetMoveVectorX(float x)
    {
        moveVector = new Vector2(x, moveVector.y);
    }

    public void StartPlayer()
    {
        Debug.Log("StartPlayer()");
        playerMoving = true;


        foreach (CodeBlockSlot cbs in codeBlockSlots)
        {
            Debug.Log(cbs.gameObject);
            DragDrop codeBlock = cbs.GetComponentInChildren<DragDrop>();



            switch (codeBlock.codeBlockInstruction)
            {
                case CodeBlockInstruction.MoveRight:
                    Debug.Log("Move Right");
                    break;

                case CodeBlockInstruction.MoveLeft:
                    Debug.Log("MoveLeft");
                    break;

                case CodeBlockInstruction.BigJump:
                    Debug.Log("BigJump");
                    break;

                case CodeBlockInstruction.SmallJump:
                    Debug.Log("SmallJumpt");
                    break;

                case CodeBlockInstruction.Grab:
                    Debug.Log("Grab");
                    break;

                default:
                    Debug.Log("No instruction found");
                    break;
            }





        }


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
        Debug.Log("GameManager: ResetPlayer()");
        resetPlayer = true;
        playerMoving = false;
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

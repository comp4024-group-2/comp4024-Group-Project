using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField] public Canvas canvas;
    private RectTransform rectTransform;

    public CodeBlockInstruction codeBlockInstruction;

    public GameManager gameManager;

    public Vector2 startPos;

    GameObject blockPanel;





    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();

        blockPanel = GameObject.Find("Block_Panel");

        startPos = transform.position;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        if (gameManager.playerStarted == true)
        {
            return;
        }
        parentAfterDrag = transform.parent;
        GameObject blockPanel = GameObject.Find("BlockOrder_Panel");
        if (blockPanel != null)
        {
            transform.SetParent(blockPanel.transform);
        }
        else
        {
            Debug.LogWarning("Could not find 'BlockOrder_panel' object in the scene.");
        }
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (gameManager.playerStarted == true)
        {
            return;
        }
        //Debug.Log("OnDrag - mouse pos : " + Input.mousePosition);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameManager.playerStarted == true)
        {
            return;
        }
        Debug.Log("OnEndDrag");
        GameObject blockPanel = GameObject.Find("BlockOrder_Panel");
        if (blockPanel != null && eventData.pointerEnter == blockPanel)
        {
            transform.SetParent(blockPanel.transform);
            transform.position = blockPanel.transform.position;
        }
        else
        {
            transform.SetParent(parentAfterDrag);
        }
        image.raycastTarget = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void ResetPosition()
    {
        transform.position = startPos;
        transform.SetParent(blockPanel.transform);
    }
}
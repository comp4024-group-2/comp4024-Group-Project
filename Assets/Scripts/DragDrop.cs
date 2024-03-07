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
        // Get the RectTransform component
        rectTransform = GetComponent<RectTransform>();

        // Find the GameManager object and get its component
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();

        // Find the "Block_Panel" object
        blockPanel = GameObject.Find("Block_Panel");

        // Store the initial position
        startPos = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        // If player has already started the game, don't allow dragging
        if (gameManager.playerStarted == true)
        {
            return;
        }
        parentAfterDrag = transform.parent;
        GameObject blockPanel = GameObject.Find("BlockOrder_Panel");
        // If found, set the parent to the panel and set it as the last child
        if (blockPanel != null)
        {
            transform.SetParent(blockPanel.transform);
        }
        else
        {
            Debug.LogWarning("Could not find 'BlockOrder_panel' object in the scene.");
        }
        transform.SetAsLastSibling();
        // Disable raycasting for the image while dragging
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // If player has already started the game, don't allow dragging
        if (gameManager.playerStarted == true)
        {
            return;
        }
        // Update the anchored position based on mouse delta and canvas scale factor
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // If player has already started the game, don't allow dragging
        if (gameManager.playerStarted == true)
        {
            return;
        }
        Debug.Log("OnEndDrag");
        GameObject blockPanel = GameObject.Find("BlockOrder_Panel");
        // If the object is dragged over the panel and the pointer entered the panel, set the parent to the panel and reset position
        if (blockPanel != null && eventData.pointerEnter == blockPanel)
        {
            transform.SetParent(blockPanel.transform);
            transform.position = blockPanel.transform.position;
        }
        else
        {
            transform.SetParent(parentAfterDrag);
        }
        // Re-enable raycasting for the image after dragging
        image.raycastTarget = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }

    public void ResetPosition()
    {
        // Reset the position and parent of the code block to its initial state
        transform.position = startPos;
        transform.SetParent(blockPanel.transform);
    }
}
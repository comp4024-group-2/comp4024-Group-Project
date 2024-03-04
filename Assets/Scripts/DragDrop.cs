using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;

    gameManager GameManager;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
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
        //Debug.Log("OnDrag - mouse pos : " + Input.mousePosition);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
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

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        GameManager.SetMoveVectorX(GameManager.moveVector.x + 1);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
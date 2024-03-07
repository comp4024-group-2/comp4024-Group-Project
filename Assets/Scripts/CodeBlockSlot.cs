using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CodeBlockSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject blockPanel = GameObject.Find("Block_Panel");
        

        Debug.Log(gameObject);
        // If the drop target is the "BlockOrder_Panel"
        if (gameObject == blockPanel)
        {
            // Allow multiple objects to be dropped
            //eventData.pointerDrag.transform.SetParent(transform, false);
            GameObject dropped = eventData.pointerDrag;
            DragDrop draggableItem = dropped.GetComponent<DragDrop>();
            draggableItem.parentAfterDrag = transform;

            DragDrop[] codeBlocks = blockPanel.GetComponentsInChildren<DragDrop>();
            DragDrop dd0 = codeBlocks[0];
        }
        // If the drop target is any other slot
        else
        {
            // Allow only one object to be dropped
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DragDrop draggableItem = dropped.GetComponent<DragDrop>();
                draggableItem.parentAfterDrag = transform;
            }

        }
    }
}

using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CodeBlockSlotTest
{
    private GameObject slotObject;
    private CodeBlockSlot slot;
    private GameObject draggableObject;
    private DragDrop dragDrop;
    private EventSystem eventSystem;

    [SetUp]
    public void Setup()
    {
        // Create a slot object with the CodeBlockSlot component
        slotObject = new GameObject("Slot");
        slot = slotObject.AddComponent<CodeBlockSlot>();

        // Create a draggable object with the DragDrop component
        draggableObject = new GameObject("Draggable");
        dragDrop = draggableObject.AddComponent<DragDrop>();

        // Set up a mock EventSystem and PointerEventData
        eventSystem = new GameObject("EventSystem").AddComponent<EventSystem>();

    }

    [Test]
    public void Test_OnDrop_SetsParentAfterDrag()
    {
        var eventData = new PointerEventData(eventSystem);
        eventData.pointerDrag = draggableObject;
        // Simulate dropping the object on the slot
        slot.OnDrop(eventData);

        // Assert that the parentAfterDrag property has been set to the slot's transform
        Assert.AreEqual(slotObject.transform, dragDrop.parentAfterDrag);
    }
}

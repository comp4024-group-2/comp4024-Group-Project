using UnityEngine;
using UnityEngine.EventSystems;
using NUnit.Framework;

public class DragDropTests
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
        // Add required components to make the test run without errors
        draggableObject.AddComponent<RectTransform>();
        dragDrop = draggableObject.AddComponent<DragDrop>();
        dragDrop.image = draggableObject.AddComponent<UnityEngine.UI.Image>();
        dragDrop.canvas = new GameObject("Canvas").AddComponent<Canvas>();
        dragDrop.gameManager = new GameManager();

        // Set up a mock EventSystem and PointerEventData
        eventSystem = new GameObject("EventSystem").AddComponent<EventSystem>();
    }

    [Test]
    public void DragDrop_DraggableObjectNotNull()
    {
        Assert.NotNull(draggableObject);
    }

    [Test]
    public void DragDrop_SlotObjectNotNull()
    {
        Assert.NotNull(slotObject);
    }

    [Test]
    public void DragDrop_DraggableComponentNotNull()
    {
        Assert.NotNull(dragDrop);
    }

    [Test]
    public void DragDrop_SlotComponentNotNull()
    {
        Assert.NotNull(slot);
    }

    [Test]
    public void DragDrop_SlotEmptyInitially()
    {
        Assert.IsTrue(slot.transform.childCount == 0);
    }

    [Test]
    public void DragDrop_DraggableCanBeDragged()
    {
        dragDrop.OnBeginDrag(new PointerEventData(eventSystem));
        Assert.IsFalse(dragDrop.image.raycastTarget);
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up created objects
        GameObject.DestroyImmediate(slotObject);
        GameObject.DestroyImmediate(draggableObject);
        GameObject.DestroyImmediate(eventSystem.gameObject);
    }
}

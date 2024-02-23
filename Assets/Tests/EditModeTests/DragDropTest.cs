using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragDropTest
{
    private GameObject draggableObject;
    private Transform initialParent;
    private DragDrop dragDrop;
    private EventSystem eventSystem;


    [SetUp]
    public void Setup()
    {
        // Create a test scene with the draggable object and its parent
        draggableObject = new GameObject("DraggableObject");
        initialParent = new GameObject("Parent").transform;
        draggableObject.transform.SetParent(initialParent);

        // Add the DragDrop script and configure the image component
        dragDrop = draggableObject.AddComponent<DragDrop>();
        dragDrop.image = draggableObject.AddComponent<Image>();

        eventSystem = new GameObject("EventSystem").AddComponent<EventSystem>();
        eventSystem.transform.SetParent(Camera.main.transform);
    }

    [Test]
    public void Test_DragAndDrop_ChangesParentAndRaycastTarget()
    {
        // Simulate dragging the object
        var camera = Camera.main; // Mock camera object
        var initialPosition = draggableObject.transform.position;
        var newPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        // Start dragging
        var eventDataBeginDrag = new PointerEventData(eventSystem);
        dragDrop.OnBeginDrag(eventDataBeginDrag); // Initialize dragging

        // Verify raycast target is disabled during dragging
        Assert.IsFalse(dragDrop.image.raycastTarget);

        // Update position during dragging
        var eventDataDrag = new PointerEventData(eventSystem);
        eventDataDrag.position = newPosition;
        dragDrop.OnDrag(eventDataDrag);

        // Verify position update during dragging
        Assert.AreNotEqual(initialPosition, draggableObject.transform.position);

        // End dragging
        var eventDataEndDrag = new PointerEventData(eventSystem);
        dragDrop.OnEndDrag(eventDataEndDrag); // End dragging

        // Verify parent reset after dropping
        Assert.AreEqual(initialParent, draggableObject.transform.parent);

        // Verify raycast target is enabled after dropping
        Assert.IsTrue(dragDrop.image.raycastTarget);
    }
}
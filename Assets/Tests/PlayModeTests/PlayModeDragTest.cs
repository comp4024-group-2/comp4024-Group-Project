using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayModeDragTest
{
    private GameObject draggableObject;
    private Transform initialParent;
    private DragDrop dragDrop;
    private EventSystem eventSystem;

    [SetUp]
    public void Setup()
    {
        // Load the test scene
        SceneManager.LoadScene("BasicPlatform");

        // Add or find the EventSystem
        eventSystem = Object.FindObjectOfType<EventSystem>();
        if (eventSystem == null)
        {
            var eventSystemGO = new GameObject("EventSystem");
            eventSystem = eventSystemGO.AddComponent<EventSystem>();
        }
    }

    [UnityTest]
    public IEnumerator Test_DragAndDrop_ChangesParentAndRaycastTarget()
    {
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        draggableObject = GameObject.FindGameObjectWithTag("Block");
        if (draggableObject == null)
        {
            Debug.LogError("draggable object is null");
        }
        initialParent = draggableObject.transform.parent;

        // Add the DragDrop script and configure the image component
        dragDrop = draggableObject.GetComponent<DragDrop>();
        dragDrop.image = draggableObject.GetComponent<Image>();

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

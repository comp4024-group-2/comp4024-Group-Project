using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayModeDragTests
{
    private GameObject draggableObject;
    private Transform initialParent;
    private DragDrop dragDrop;
    private EventSystem eventSystem;

    [SetUp]
    public void Setup()
    {
        // Load the test scene
        SceneManager.LoadScene("CollatedScene");

        // Add or find the EventSystem
        eventSystem = Object.FindObjectOfType<EventSystem>();
        if (eventSystem == null)
        {
            var eventSystemGO = new GameObject("EventSystem");
            eventSystem = eventSystemGO.AddComponent<EventSystem>();
        }
    }

    [UnityTest]
    public IEnumerator Test_DragAndDrop_UpdatesPositionDuringDragging()
    {
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        draggableObject = GameObject.Find("MoveRight");
        initialParent = draggableObject.transform.parent;
        var initialPosition = draggableObject.transform.position;

        // Simulate dragging the object
        SimulateDragging();

        // Verify position update during dragging
        Assert.AreNotEqual(initialPosition, draggableObject.transform.position);
    }

    [UnityTest]
    public IEnumerator Test_DragAndDrop_ResetsParentAfterDropping()
    {
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        draggableObject = GameObject.Find("MoveRight");
        initialParent = draggableObject.transform.parent;

        // Simulate dragging the object
        SimulateDragging();

        // Verify parent reset after dropping
        Assert.AreEqual(initialParent, draggableObject.transform.parent);
    }

    [UnityTest]
    public IEnumerator Test_DragAndDrop_EnablesRaycastTargetAfterDropping()
    {
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        draggableObject = GameObject.Find("MoveRight");
        initialParent = draggableObject.transform.parent;

        // Simulate dragging the object
        SimulateDragging();

        // Verify raycast target is enabled after dropping
        Assert.IsTrue(dragDrop.image.raycastTarget);
    }

    // Helper method to simulate dragging
    private void SimulateDragging()
    {
        dragDrop = draggableObject.GetComponent<DragDrop>();
        dragDrop.image = draggableObject.GetComponent<Image>();
        dragDrop.gameManager = new GameManager();

        // Mock camera object
        var camera = Camera.main;
        var newPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        // Start dragging
        var eventDataBeginDrag = new PointerEventData(eventSystem);
        dragDrop.OnBeginDrag(eventDataBeginDrag); // Initialize dragging

        // Update position during dragging
        var eventDataDrag = new PointerEventData(eventSystem);
        eventDataDrag.position = newPosition;
        dragDrop.OnDrag(eventDataDrag);

        // End dragging
        var eventDataEndDrag = new PointerEventData(eventSystem);
        dragDrop.OnEndDrag(eventDataEndDrag); // End dragging
    }
}

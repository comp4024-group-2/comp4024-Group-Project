using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneChangeMainTest
{
    private EventSystem eventSystem;

    [SetUp]
    public void Setup()
    {
        // Load the test scene
        SceneManager.LoadScene("Main");

        // Add or find the EventSystem
        eventSystem = Object.FindObjectOfType<EventSystem>();
        if (eventSystem == null)
        {
            var eventSystemGO = new GameObject("EventSystem");
            eventSystem = eventSystemGO.AddComponent<EventSystem>();
        }
    }

    [UnityTest]
    public IEnumerator Test_LoadMainMenuScene()
    {
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Verify that the current scene is the main menu scene
        Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator Test_FindButtonInScene()
    {
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Find the button GameObject in the scene
        GameObject startButtonObject = GameObject.Find("StartButton");
        Button startButton = startButtonObject.GetComponent<Button>();
        Assert.IsNotNull(startButton, "Button not found in the scene");
    }

    [UnityTest]
    public IEnumerator Test_SimulateStartButtonClick_LoadsCollatedScene()
    {
     
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Find the button GameObject in the scene
        GameObject startButtonObject = GameObject.Find("StartButton");
        Button startButton = startButtonObject.GetComponent<Button>();

        // Simulate a button click
        startButton.onClick.Invoke();

        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Verify that the current scene is the CollatedScene
        Assert.AreEqual("CollatedScene", SceneManager.GetActiveScene().name);
    }
}


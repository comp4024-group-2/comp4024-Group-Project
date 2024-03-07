using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneChangeCollatedTests
{
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
    public IEnumerator Test_LoadCollatedScene()
    {
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Verify that the current scene is the main menu scene
        Assert.AreEqual("CollatedScene", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator Test_FindHomeButtonInScene()
    {
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Find the button GameObject in the scene
        GameObject homeButtonObject = GameObject.Find("HomeButton");
        Button homeButton = homeButtonObject.GetComponent<Button>();
        Assert.IsNotNull(homeButton, "Button not found in the scene");
    }

    [UnityTest]
    public IEnumerator Test_SimulateHomeButtonClick_LoadsMainScene()
    {

        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Find the button GameObject in the scene
        GameObject homeButtonObject = GameObject.Find("HomeButton");
        Button homeButton = homeButtonObject.GetComponent<Button>();

        // Simulate a button click
        homeButton.onClick.Invoke();

        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Verify that the current scene is the CollatedScene
        Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
    }
}


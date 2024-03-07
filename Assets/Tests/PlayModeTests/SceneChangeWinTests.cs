using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChangeWinTests
{
    private EventSystem eventSystem;

    [SetUp]
    public void Setup()
    {
        // Load the test scene
        SceneManager.LoadScene("WinScene");

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
        Assert.AreEqual("WinScene", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator Test_FindMainMenuButtonInScene()
    {
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Find the button GameObject in the scene
        GameObject buttonObject = GameObject.Find("MainMenuButton");
        Button button = buttonObject.GetComponent<Button>();
        Assert.IsNotNull(button, "Button not found in the scene");
    }

    [UnityTest]
    public IEnumerator Test_FindNextLevelButtonInScene()
    {
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Find the button GameObject in the scene
        GameObject buttonObject = GameObject.Find("NextLevelButton");
        Button button = buttonObject.GetComponent<Button>();
        Assert.IsNotNull(button, "Button not found in the scene");
    }

    [UnityTest]
    public IEnumerator Test_FindUpperLeftButtonInScene()
    {
        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Find the button GameObject in the scene
        GameObject buttonObject = GameObject.Find("UpperLeftButton");
        Button button = buttonObject.GetComponent<Button>();
        Assert.IsNotNull(button, "Button not found in the scene");
    }

    [UnityTest]
    public IEnumerator Test_SimulateMainMenuButtonClick_LoadsMainScene()
    {

        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Find the button GameObject in the scene
        GameObject buttonObject = GameObject.Find("MainMenuButton");
        Button button = buttonObject.GetComponent<Button>();

        // Simulate a button click
        button.onClick.Invoke();

        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Verify that the current scene is the CollatedScene
        Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator Test_SimulateNextLevelButtonClick_LoadsMainScene()
    {

        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Find the button GameObject in the scene
        GameObject buttonObject = GameObject.Find("NextLevelButton");
        Button button = buttonObject.GetComponent<Button>();

        // Simulate a button click
        button.onClick.Invoke();

        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Verify that the current scene is the CollatedScene
        Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator Test_SimulateUpperLeftButtonClick_LoadsCollatedScene()
    {

        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Find the button GameObject in the scene
        GameObject buttonObject = GameObject.Find("UpperLeftButton");
        Button button = buttonObject.GetComponent<Button>();

        // Simulate a button click
        button.onClick.Invoke();

        // Wait for one frame to ensure the scene is fully loaded
        yield return null;

        // Verify that the current scene is the CollatedScene
        Assert.AreEqual("CollatedScene", SceneManager.GetActiveScene().name);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeTest
{
    [UnityTest]
    public IEnumerator ButtonClick_ChangesScene()
    {
        // Load the scene containing the button
        SceneManager.LoadScene("Main");

        // Wait for one frame to ensure scene is loaded
        yield return null;

        // Find the button GameObject by its name
        GameObject buttonGO = GameObject.Find("Start");

        // Check if button exists
        Assert.IsNotNull(buttonGO, "Button GameObject not found in scene.");

        // Get the Button component
        Button button = buttonGO.GetComponent<Button>();

        // Check if Button component exists
        Assert.IsNotNull(button, "Button component not found on GameObject.");

        // Get the current scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Add scene load listener
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Simulate a button click
        button.onClick.Invoke();

        // Wait for the new scene to load
        while (SceneManager.GetActiveScene() == currentScene)
        {
            yield return null;
        }

        // Remove scene load listener
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Check if the scene has changed
        Assert.AreEqual("Game_page", SceneManager.GetActiveScene().name, "Scene did not change after button click.");
    }

    // Scene load callback
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    
    }
}

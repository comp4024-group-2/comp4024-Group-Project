using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class InterfaceTransitionTest
{
    [UnityTest]
    public IEnumerator TransitionFromMainToGamePage()
    {
        // Load the Main scene synchronously
        SceneManager.LoadScene("Main", LoadSceneMode.Single);

        // Wait for the scene to be fully loaded
        yield return null;

        // Find the start button
        Button startButton = GameObject.FindObjectOfType<Button>();
        Assert.IsNotNull(startButton, "Start button not found in Main interface");

        // Simulate button click
        startButton.onClick.Invoke();

        // Wait for the next frame to ensure the scene transition callback is registered
        yield return null;

        // Ensure that the scene transition occurred
        Assert.AreEqual("Game_page", SceneManager.GetActiveScene().name, "Failed to transition to Game_page interface");
    }
}
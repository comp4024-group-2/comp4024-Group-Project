using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerMovement
{
    [Test]
    public void PlayerMovesRightWhenRightArrowPressed()
    {
        // Arrange
        var playerMovement = new PlayerMovement(); // Create an instance

        // Act
        Input.GetAxis("Horizontal"); // Simulate right arrow press
        playerMovement.playersMove = 1f;
        playerMovement.Update(); // Call the Update method

        // Assert
        Assert.AreEqual(7f, playerMovement.rb.velocity.x); // Check if velocity updates
    }
}

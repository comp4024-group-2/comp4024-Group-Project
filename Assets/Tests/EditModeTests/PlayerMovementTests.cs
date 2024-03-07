using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class PlayerMovementTests
{
    private PlayerMovement playerMovement;

    [SetUp]
    public void Setup()
    {
        // Create a test GameObject with the PlayerMovement component
        GameObject testObject = new GameObject("TestPlayer");

        // Add Rigidbody component to the test GameObject
        Rigidbody2D rigidbody = testObject.AddComponent<Rigidbody2D>();

        // Add PlayerMovement component to the test GameObject
        playerMovement = testObject.AddComponent<PlayerMovement>();

        // Assign the Rigidbody2D to the playerMovement script
        playerMovement.rb = rigidbody;

        // Create a test instance of the GameManager class
        GameManager gameManager = new GameManager();

        // Assign the test GameManager instance to the playerMovement script
        playerMovement.gameManager = gameManager;
    }

    [Test]
    public void Test_MoveRight_ChangesSpeed_Positive()
    {
        // Set the speed to 0 initially
        playerMovement.speed = 0f;

        // Call the MoveRight method
        playerMovement.MoveRight();

        // Verify that the speed changes to a positive value
        Assert.Greater(playerMovement.speed, 0f);
    }

    [Test]
    public void Test_MoveLeft_ChangesSpeed_Negative()
    {
        // Set the speed to 0 initially
        playerMovement.speed = 0f;

        // Call the MoveLeft method
        playerMovement.MoveLeft();

        // Verify that the speed changes to a negative value
        Assert.Less(playerMovement.speed, 0f);
    }

    [Test]
    public void Test_Jump_ChangesJumpingState()
    {
        // Set the jumping state to false initially
        playerMovement.isJumping = false;

        // Call the Jump method
        playerMovement.PrepareJump(100f);
        playerMovement.Jump();

        // Verify that the jumping state changes to true
        Assert.IsTrue(playerMovement.isJumping);
    }

    [Test]
    public void Test_ResetPlayer_ResetsPosition()
    {
        // Set the initial position
        Vector2 initialPosition = new Vector2(1f, 2f);
        playerMovement.transform.position = initialPosition;

        // Call the ResetPlayer method
        playerMovement.ResetPlayer();

        Vector2 newPos = playerMovement.transform.position;

        // Verify that the position resets to its initial position
        Assert.AreEqual(playerMovement.startPos, newPos);
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up created objects
        GameObject.DestroyImmediate(playerMovement.gameObject);
    }
}

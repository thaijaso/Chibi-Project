using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float Speed = 1.0f;
    public float JumpStrength = 1.0f;

    // Moves the player in the specified direction
    public void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            // Normalize the direction vector to ensure consistent speed
            direction.Normalize();

            // Rotate the Rigidbody to face the direction of movement
            PlayerRigidbody.rotation = Quaternion.LookRotation(direction);

            // Move the Rigidbody in the specified direction
            PlayerRigidbody.MovePosition(PlayerRigidbody.position + Speed * Time.fixedDeltaTime * direction);
        }
    }

    // Makes the player jump
    public void Jump()
    {
        PlayerRigidbody.linearVelocity = Vector3.up * JumpStrength;
    }

    public bool IsGrounded()
    {
        // Perform a raycast to check if the player is on the ground
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}

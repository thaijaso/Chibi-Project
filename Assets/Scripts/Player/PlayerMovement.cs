using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float Speed = 1.0f;
    public float JumpStrength = 1.0f;
    public bool IsGrounded { get; private set; }

private void Start()
    {
        PlayerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        IsGrounded = true;
    }

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
    public bool IsAirborne()
    {
        // Check if the player is airborne by checking if the vertical velocity is greater than 0
        return !IsGrounded || Mathf.Abs(PlayerRigidbody.linearVelocity.y) > 0.01f;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if the player is no longer grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

}

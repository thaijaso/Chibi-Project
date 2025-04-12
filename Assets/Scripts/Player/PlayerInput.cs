using UnityEngine;
using System.Collections;


public class PlayerInput : MonoBehaviour
{
    public float MovementThreshold = 0.2f;
    public bool IsMoving { get; internal set; }
    public bool IsJumping { get; internal set; }

    // Update is called once per frame
    void Update()
	{
        // Check if the horizontal or vertical axis exceeds the threshold
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        IsMoving = Mathf.Abs(horizontal) > MovementThreshold || Mathf.Abs(vertical) > MovementThreshold;
        IsJumping = Input.GetButtonDown("Jump");
    }

    public Vector3 GetMovementDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector3(horizontal, 0, vertical).normalized;
    }
}

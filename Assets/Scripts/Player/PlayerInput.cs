﻿using UnityEngine;
using System.Collections;


public class PlayerInput : MonoBehaviour
{
    public float MovementThreshold = 0.2f;
    public bool IsMoving { get; internal set; }
    public bool IsJumping { get; internal set; }
    public bool IsAiming { get; internal set; }
    public bool IsShooting { get; internal set; }

    // Update is called once per frame
    void Update()
	{
        // Check if the horizontal or vertical axis exceeds the threshold
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        IsMoving = Mathf.Abs(horizontal) > MovementThreshold || Mathf.Abs(vertical) > MovementThreshold;

        IsJumping = Input.GetButtonDown("Jump");
        IsAiming = Input.GetButton("Fire2");
        IsShooting = Input.GetButton("Fire1") && Input.GetButton("Fire2");
    }

    public Vector3 GetMovementDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector3(horizontal, 0, vertical).normalized;
    }
}

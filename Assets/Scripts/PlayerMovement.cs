using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Handle touch input
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch != null)
        {
            HandleTouchInput();
        }
        else
        {
            // Handle keyboard controls
            movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            HandleMovementInput();
        }
    }

private Vector2 smoothedTouchDelta = Vector2.zero;

private void HandleTouchInput()
{
    Vector2 touchDelta = Touchscreen.current.primaryTouch.delta.ReadValue();
    smoothedTouchDelta = Vector2.Lerp(smoothedTouchDelta, touchDelta, 0.5f); // Menggunakan interpolasi linier untuk smoothing
    movement = smoothedTouchDelta.normalized;
    HandleMovementInput();
}
    private void HandleMovementInput()
    {
        if (movement.magnitude > 0)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * MoveSpeed;
    }
}

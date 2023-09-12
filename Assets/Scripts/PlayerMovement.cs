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
    public Joystick joystick; // Reference to your joystick UI element

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Handle joystick controls
        if (joystick != null)
        {
            movement = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
        else
        {
            // Fallback to keyboard controls if joystick is not assigned
            movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        if (movement.x != 0 || movement.y != 0)
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
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the object you want to interact with.
        if (collision.gameObject.CompareTag("Sampah"))
        {
            // Perform your interaction logic here.
            Debug.Log("Player hit the interactable object!");
            
            // You can access the collided object using 'collision.gameObject'.
            // For example, you could deactivate it:
            // collision.gameObject.SetActive(false);
        }
    }
}

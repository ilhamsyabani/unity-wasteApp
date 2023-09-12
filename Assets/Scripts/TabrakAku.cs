using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabrakAku : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject materi;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the object you want to interact with.
        if (collision.gameObject.name.Equals("Player"))
        {
            // Perform your interaction logic here.

            Debug.Log("Player hit the interactable object!");
            Destroy(gameObject);
            materi.SetActive(true);

            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

            // Set the player's MoveSpeed to 0 to stop their movement.
            if (playerMovement != null)
            {
                playerMovement.MoveSpeed = 0f;
            }
        }
    }
}

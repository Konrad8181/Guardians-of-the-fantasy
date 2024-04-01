using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to change the player's movement speed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player GameObject
    }

    void Update()
    {
        // Get input from the player
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calculate the movement direction
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Move the player
        rb.velocity = movement * moveSpeed;
    }
}

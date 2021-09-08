using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Transform player;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Vertical2");
        movement.y = Input.GetAxisRaw("Horizontal2");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
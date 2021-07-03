using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;

    [SerializeField] float speed = 2f;
    [SerializeField] float jumpForce = 5.0f;

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);

        Debug.Log(IsGrounded() ? "isGrounded" : "isNotGrounded");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, .6f, LayerMask.GetMask("Ground"));

        return hit.collider;
    }
}

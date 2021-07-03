using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;

    [SerializeField] float speed = 2f;

    void Start()
    {
        
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontalInput, rb.velocity.y) * speed * Time.deltaTime;
    }
}

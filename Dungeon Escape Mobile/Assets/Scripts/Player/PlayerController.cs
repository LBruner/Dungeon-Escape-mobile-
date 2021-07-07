using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private Animator playerAnimator = null;
    [SerializeField] private Animator swordArcAnimator = null;
    [SerializeField] private SpriteRenderer playerSprite = null;
    [SerializeField] private SpriteRenderer swordSprite = null;

    [SerializeField] int health = 5;
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] int playerGems = 0;

    public int Health { get; set; }

    private void Start()
    {
        Health = health;
        Diamond.OnEnemyKilled += CollectGems;
    }

    void FixedUpdate()
    {
        if (IsDead()) { return; }

        Movement();
        Attack();

        if(Input.GetKeyDown(KeyCode.UpArrow))
            Time.timeScale -= .1f;
        if(Input.GetKeyDown(KeyCode.DownArrow))
            Time.timeScale += .1f;
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);

        //Debug.Log(IsGrounded() ? "isGrounded" : "isNotGrounded");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playerAnimator.SetBool("isJumping", true);
        }
        else if(IsGrounded())
            playerAnimator.SetBool("isJumping", false);

        HandleMoveAnimation(horizontalInput);        
    }

    private void Attack()
    {
        if(Input.GetMouseButtonDown(0) && IsGrounded())
        {
            playerAnimator.SetTrigger("attack");
            swordArcAnimator.SetTrigger("swordAnimation");
        }
    }

    private void HandleMoveAnimation(float horizontalInput)
    {
        playerAnimator.SetFloat("move", Mathf.Abs(horizontalInput));

        if(horizontalInput < 0)
        {
            playerSprite.flipX = true;

            swordSprite.flipY = true;
            swordSprite.transform.localPosition = new Vector2(-0.749f, swordSprite.transform.localPosition.y);
        }

        if(horizontalInput > 0)
        {
            playerSprite.flipX = false;

            swordSprite.flipY = false;
            swordSprite.transform.localPosition = new Vector2(+0.749f, swordSprite.transform.localPosition.y);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, .6f, LayerMask.GetMask("Ground"));

        return hit.collider;
    }

    public void HandleDamage(int damageAmount)
    {
        if (IsDead()) { return; }

        health = (Mathf.Max(health - damageAmount, 0));

        if (health == 0)
            playerAnimator.SetTrigger("isDead");
    }

    private void CollectGems(int rewardGems)
    {
        playerGems += rewardGems;
    }

    public bool IsDead()
    {
        return health == 0;
    }
}

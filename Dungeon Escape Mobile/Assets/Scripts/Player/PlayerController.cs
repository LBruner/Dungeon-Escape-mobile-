using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;


namespace Player
{
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

        public static Action<int> OnTakeDamage;

        public int Health
        {
            get;set;
        }

        public static PlayerController instance;

        public static PlayerController Player
        {
            get
            {if (instance == null)
                    instance = new PlayerController();
                return instance;
            }       
        }

        private void Start()
        {
            Health = health;
            Diamond.OnCollectGems += AddGems;
            Diamond.GetPlayerGems += GetPlayerGems;
        }

        private void OnDestroy()
        {
            Diamond.OnCollectGems -= AddGems;
            Diamond.GetPlayerGems -= GetPlayerGems;
        }

        void FixedUpdate()
        {
            if (IsDead()) { return; }

            Movement();
            Attack();

            if (Input.GetKeyDown(KeyCode.UpArrow))
                Time.timeScale -= .1f;
            if (Input.GetKeyDown(KeyCode.DownArrow))
                Time.timeScale += .1f;
        }

        private void Movement()
        {
            // float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
            float horizontalInput = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);

            //Debug.Log(IsGrounded() ? "isGrounded" : "isNotGrounded");

            if ((Input.GetKeyDown(KeyCode.Space) && IsGrounded()))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                playerAnimator.SetBool("isJumping", true);
            }
            else if (IsGrounded())
                playerAnimator.SetBool("isJumping", false);

            HandleMoveAnimation(horizontalInput);
        }

        private void Attack()
        {
            if (Input.GetMouseButtonDown(0) && IsGrounded())
            {
                playerAnimator.SetTrigger("attack");
                swordArcAnimator.SetTrigger("swordAnimation");
            }
        }

        private void HandleMoveAnimation(float horizontalInput)
        {
            playerAnimator.SetFloat("move", Mathf.Abs(horizontalInput));

            if (horizontalInput < 0)
            {
                playerSprite.flipX = true;

                swordSprite.flipY = true;
                swordSprite.transform.localPosition = new Vector2(-0.749f, swordSprite.transform.localPosition.y);
            }

            if (horizontalInput > 0)
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


            Health = (Mathf.Max(Health - damageAmount, 0));

            OnTakeDamage?.Invoke(Health);

            if (Health == 0)
                playerAnimator.SetTrigger("isDead");
        }

        public void AddGems(int rewardGems)
        {
            playerGems += rewardGems;
        }

        public void SetPlayerGems(int newGemsAmount)
        {
            playerGems = newGemsAmount;
        }

        public int GetPlayerGems()
        {
            return playerGems;
        }

        public bool IsDead()
        {
            return Health == 0;
        }
    }
}

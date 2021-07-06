using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected Animator enemyAnimator = null;
    [SerializeField] protected SpriteRenderer enemySprite = null;
    [SerializeField] protected Transform pointA = null, pointB = null;

    [SerializeField] protected bool isGoingLeft = true;
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;

    protected Vector3 currentTarget;
    protected bool isHit = false;
    protected Transform playerPos;

    public int Health { get; set; }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (IsIdle() && !isHit) { return; }

        Movement();
    }


    public virtual void Init()  
    {
        Health = health;
    }

    private void Movement()
    {
        if (currentTarget == pointA.position)
            enemySprite.flipX = true;
        else
            enemySprite.flipX = false;

        if (transform.position.x == pointA.position.x)
        {
            enemyAnimator.SetTrigger("idle");
            currentTarget = pointB.position;
        }
        else if (transform.position.x == pointB.position.x)
        {
            enemyAnimator.SetTrigger("idle");
            currentTarget = pointA.position;
        }

        if(!isHit)
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        else
        {
            playerPos = FindObjectOfType<PlayerController>().transform;

            Vector2 direction = playerPos.position - transform.position;

            if(direction.x < 0)
                enemySprite.flipX = true;
            else
                enemySprite.flipX = false;

            if((playerPos.position - transform.position).sqrMagnitude > 2 * 2)
            {
                enemyAnimator.SetBool("inCombat", false);
                isHit = false;
            }
        }       
    }

    public void HandleDamage(int damageAmount)
    {
        health = (Mathf.Max(health - damageAmount, 0));

        if (health == 0)
            Debug.Log("E morreu");

        enemyAnimator.SetTrigger("hit");
        enemyAnimator.SetBool("inCombat", true);
        isHit = true;
    }
    
    private bool IsIdle()
    {
        return enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
    }

}

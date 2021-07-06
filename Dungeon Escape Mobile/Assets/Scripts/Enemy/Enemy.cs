using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public abstract class Enemy : MonoBehaviour
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

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (IsIdle()) { return; }

        Movement();
    }


    public virtual void Init()  
    {
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
    }

    private bool IsIdle()
    {
        return enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
    }

}

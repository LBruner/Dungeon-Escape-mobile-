using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    Vector3 currentTarget;
    private void Start()
    {
    }
    public override void FixedUpdate()
    {
        if (IsIdle()) { return; }

        Debug.Log(currentTarget);
        Movement();
    }

    private void Movement()
    {
        if(currentTarget.x <= pointA.position.x)
            enemySprite.flipX = true;
        else
            enemySprite.flipX = false;

        if (transform.position.x < pointA.position.x +.2f)
        {
            currentTarget = pointB.position;
            enemyAnimator.SetTrigger("idle");
        }
        else if (transform.position.x > pointB.position.x -.2f)
        {
            currentTarget = pointA.position;
            enemyAnimator.SetTrigger("idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    private bool IsIdle()
    {
        return enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
    }
}

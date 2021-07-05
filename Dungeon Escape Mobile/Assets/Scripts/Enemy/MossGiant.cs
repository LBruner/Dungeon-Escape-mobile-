using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    Vector3 currentTarget;

    public override void Update()
    {
        if (IsIdle()) { return; }

        Debug.Log(currentTarget);
        Movement();
    }

    private void Movement()
    {
        if(currentTarget == pointA.position)
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

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    private bool IsIdle()
    {
        return enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
    }
}

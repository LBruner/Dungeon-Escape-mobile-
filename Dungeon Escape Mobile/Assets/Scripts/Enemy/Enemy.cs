using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Animator enemyAnimator = null;
    [SerializeField] protected SpriteRenderer enemySprite = null;
    [SerializeField] protected Transform pointA = null, pointB = null;

    [SerializeField] protected bool isGoingLeft = true;
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;


    private void Start()
    {
        
    }

    public abstract void Update();

}

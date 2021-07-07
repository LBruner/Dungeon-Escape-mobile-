using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] int rewardGems = 0;

    public static Action<int> OnEnemyKilled;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            OnEnemyKilled?.Invoke(rewardGems);
            Destroy(gameObject);
        }
    }

    public void SetRewardGems(int enemyGems)
    {
        rewardGems = enemyGems;
    }
}

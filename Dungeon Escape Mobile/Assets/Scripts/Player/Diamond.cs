using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] int rewardGems = 0;

    private int currentPlayerGemCount = 0;

    public static Action<int> OnCollectGems;
    public static Func<int> GetPlayerGems;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            OnCollectGems?.Invoke(rewardGems);
            currentPlayerGemCount = (int)(GetPlayerGems?.Invoke());
            Shop.OnUpdateUI?.Invoke(currentPlayerGemCount);
            //Debug.Log(currentPlayerGemCount);
            Destroy(gameObject);
        }
    }

    public void SetRewardGems(int enemyGems)
    {
        rewardGems = enemyGems;
    }
}

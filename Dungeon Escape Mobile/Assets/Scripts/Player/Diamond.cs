using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Diamond : MonoBehaviour
    {
        [SerializeField] int rewardGems = 0;

        private int currentPlayerGemCount = 0;

        public static Action<int> OnCollectGems;
        public static Func<int> GetPlayerGems;

        public static Diamond instance;

        public static Diamond diamond
        {
            get
            {
                if(instance == null)
                    instance = new Diamond();
                return instance;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
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
}

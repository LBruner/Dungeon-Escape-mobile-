using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Action<int> OnEnableShop;

    private int currentPlayerGemCount;

    [SerializeField] GameObject shopPanelObject = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.TryGetComponent<PlayerController>(out PlayerController player);

            if(player != null)
                currentPlayerGemCount = player.GetPlayerGems();

            OnEnableShop?.Invoke(currentPlayerGemCount);

            shopPanelObject.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            shopPanelObject.gameObject.SetActive(false);
    }
}

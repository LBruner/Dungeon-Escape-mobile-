using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Action<int> OnUpdateUI;
    public static Action<int> OnSelectItem;

    public static Action<int> OnBuyItem;

    private int currentPlayerGemCount;
    private int currentItemSelected;
    private int currentItemPrice;
    private PlayerController player = null;

    [SerializeField] GameObject shopPanelObject = null;

    public void SelectItem(int choosenItem)
    {
        switch(choosenItem)
        {
            case 0: OnSelectItem(64); currentItemSelected = 0; currentItemPrice = 200;
                break;
            case 1: OnSelectItem(-37); currentItemSelected = 1; currentItemPrice = 400;
                break;              
            case 2: OnSelectItem(-144); currentItemSelected = 2; currentItemPrice = 50;
                break;               
        }
    }

    public void BuyItem()
    {
        if(currentPlayerGemCount >= currentItemPrice)
        {
            player.SetPlayerGems(player.GetPlayerGems() - currentItemPrice);

            OnUpdateUI?.Invoke(player.GetPlayerGems());
            OnBuyItem?.Invoke(currentItemSelected);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.TryGetComponent<PlayerController>(out PlayerController player);

            if(player != null)
            {
                this.player = player;
                currentPlayerGemCount = player.GetPlayerGems();
            }

            OnUpdateUI?.Invoke(currentPlayerGemCount);

            shopPanelObject.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            shopPanelObject.gameObject.SetActive(false);
    }
}

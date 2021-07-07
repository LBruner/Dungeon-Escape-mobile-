using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerGemsText = null;
    [SerializeField] private Image selectionImage = null;
    private static UIManager instance;
    public static UIManager UIInstance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {   
        instance = this;
        Shop.OnEnableShop += OpenShop;
        Shop.OnSelectItem += UpdateShopSelection;
    }

    public void OpenShop(int playerGems)
    {
        playerGemsText.text = playerGems + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerGemsText = null;
    [SerializeField] private Image selectionImage = null;
    [SerializeField] TextMeshProUGUI gemsText = null;   

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
        Shop.OnUpdateUI += UpdateGemsUI;
        Shop.OnSelectItem += UpdateShopSelection;
        Shop.OnUpdateUI += UpdateGemsUI;
    }

    private void OnDestroy()
    {
        Shop.OnUpdateUI -= UpdateGemsUI;
        Shop.OnSelectItem -= UpdateShopSelection;
        Diamond.OnCollectGems -= UpdateGemsUI;
    }

    public void UpdateGemsUI(int playerGems)
    {
        Debug.Log(playerGems);
        gemsText.text = playerGems + "G";
        playerGemsText.text = playerGems + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.gameObject.SetActive(true);
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }
}

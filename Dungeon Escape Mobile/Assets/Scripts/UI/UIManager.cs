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

    [SerializeField] private Image[] healthUnitImages;

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
        PlayerController.OnTakeDamage += UpdateHealthImages;
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

    public void UpdateHealthImages(int currentLives)
    {
        Debug.Log(currentLives);
        for (int i = currentLives + 1; i > currentLives; i--)
        {
            healthUnitImages[i - 1].gameObject.SetActive(false);
        }
    }
}

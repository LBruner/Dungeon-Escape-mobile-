using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent OnBuySword;
    [SerializeField] UnityEvent OnBuyBoots;
    private bool hasKey = false;

    public static GameManager GameManagerInstance;
    public static GameManager instance
    {
        get {return instance; }
    }

    private void Awake()
    {
        GameManagerInstance = this;

        Shop.OnBuyItem += HandleItems;
    }

    private void HandleItems(int itemID)
    {
        switch (itemID)
        {
            case 0:
                OnBuySword?.Invoke();
                break;
            case 1:
                OnBuyBoots?.Invoke();
                break;
            case 2:
                hasKey = true;
                break;
        }
    }
}

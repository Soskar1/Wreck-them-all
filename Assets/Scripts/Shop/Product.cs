using UnityEngine.UI;
using UnityEngine;
using System;

public class Product : MonoBehaviour
{
    private Coins _coins;
    private Brains _brains;
    [HideInInspector] public ShopItemDisplay shopItemDisplay;

    public Action<ShopItem> OnPurchasingEvent;

    private void Awake()
    {
        shopItemDisplay = GetComponent<ShopItemDisplay>();

        switch(shopItemDisplay.currency)
        {
            case Collectible.CollectibleType.coin:
                if (FindObjectOfType<Coins>() != null)
                    _coins = FindObjectOfType<Coins>();
                break;

            case Collectible.CollectibleType.brain:
                if (FindObjectOfType<Brains>() != null)
                    _brains = FindObjectOfType<Brains>();
                break;
        }
    }

    public void Buy()
    {
        int _decoy;

        switch (shopItemDisplay.currency)
        {
            case Collectible.CollectibleType.coin:
                _decoy = _coins.Currency;
                _coins.Currency = RedactCurrency(_decoy);
                break;

            case Collectible.CollectibleType.brain:
                _decoy = _brains.Currency;
                _brains.Currency = RedactCurrency(_decoy);
                break;
        }
    }

    private int RedactCurrency(int currency)
    {
        if (currency >= shopItemDisplay.shopItem.price)
        {
            currency -= shopItemDisplay.shopItem.price;
            shopItemDisplay.DeletePrice();

            OnPurchasingEvent?.Invoke(shopItemDisplay.shopItem);
        }

        return currency;
    }
}

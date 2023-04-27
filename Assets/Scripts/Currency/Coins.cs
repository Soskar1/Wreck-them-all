using System;
using UnityEngine;

public class Coins : Currencies
{
    [SerializeField] private ShopItem _coinMultiplierShopItem;
    [SerializeField] private Product _coinMultiplierProduct;

    private void Awake()
    {
        Currency = PlayerPrefs.GetInt(_currencyName, 0);

        multiplier = Convert.ToBoolean(PlayerPrefs.GetInt(_coinMultiplierShopItem.name));

        if (_coinMultiplierShopItem.unlocked)
            ActivateMultiplier(_coinMultiplierShopItem);
        else
            _coinMultiplierProduct.OnPurchasingEvent += ActivateMultiplier;
    }

    private void ActivateMultiplier(ShopItem shopItem)
    {
        multiplier = true;
        PlayerPrefs.SetInt(shopItem.name, Convert.ToInt32(multiplier));
    }
}

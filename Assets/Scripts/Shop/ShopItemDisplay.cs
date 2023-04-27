using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemDisplay : MonoBehaviour
{
    public ShopItem shopItem;
    public Collectible.CollectibleType currency;

    [SerializeField] private Image _visual;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private TextMeshProUGUI _name;

    [SerializeField] private GameObject _soldImage;

    private const string BRAIN_SPRITE_CODE = "<sprite=0>";
    private const string COIN_SPRITE_CODE = "<sprite=1>";

    private void Awake()
    {
        _visual.sprite = shopItem.visual;
        _name.SetText(shopItem.name);

        if (currency == Collectible.CollectibleType.coin)
            _priceText.SetText(shopItem.price.ToString() + COIN_SPRITE_CODE);
        else
            _priceText.SetText(shopItem.price.ToString() + BRAIN_SPRITE_CODE);

        string key = shopItem.name + "Unlocked";
        shopItem.unlocked = Convert.ToBoolean(PlayerPrefs.GetInt(key));
        if (shopItem.unlocked)
            DeletePrice();
    }

    public void DeletePrice()
    {
        _priceText.gameObject.SetActive(false);
        _soldImage.SetActive(true);

        shopItem.unlocked = true;
        string key = shopItem.name + "Unlocked";
        PlayerPrefs.SetInt(key, Convert.ToInt32(shopItem.unlocked));

        GetComponentInChildren<Button>().interactable = false;
    }
}

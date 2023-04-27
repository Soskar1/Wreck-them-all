using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EquipmentDisplay : MonoBehaviour
{
    [SerializeField] private Equipment _equipment;
    [SerializeField] private Upgrade _upgrade;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _visual;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _equipButton;

    [SerializeField] private bool unlockedByDefault;

    private void OnEnable() => WeaponUpgradeCheck();

    private void Awake()
    {
        //string key = _equipment.shopItem.name + "Unlocked";
        //PlayerPrefs.SetInt(key, Convert.ToInt32(_equipment.shopItem.unlocked));

        _name.SetText(_equipment.name);
        _visual.sprite = _equipment.visual;

        _upgrade.OnUpgradingEvent += WeaponUpgradeCheck;
    }

    public void UpgradeWeapon()
    {
        _upgrade.equipment = _equipment;
        _upgrade.gameObject.SetActive(true);
    }

    private void WeaponUpgradeCheck()
    {
        if (!unlockedByDefault)
        {
            string key = _equipment.shopItem.name + "Unlocked";
            _equipment.shopItem.unlocked = Convert.ToBoolean(PlayerPrefs.GetInt(key));
        }

        if (_equipment.shopItem.unlocked)
        {
            _equipButton.interactable = true;

            if (_equipment.lvl >= _equipment.maxLvl)
                _upgradeButton.interactable = false;
            else
                _upgradeButton.interactable = true;
        }
        else
        {
            _equipButton.interactable = false;
            _upgradeButton.interactable = false;
        }
    }
}

using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class Upgrade : MonoBehaviour
{
    [HideInInspector] public Equipment equipment;

    private Coins _coins;

    public Action OnUpgradingEvent;

    [Space(15f)]

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _visual;

    [Space(15f)]

    [SerializeField] private TextMeshProUGUI _currentLvl;
    [SerializeField] private TextMeshProUGUI _nextLvl;

    [Space(15f)]

    [SerializeField] private TextMeshProUGUI _currentDmg;
    [SerializeField] private TextMeshProUGUI _nextDmg;

    [Space(15f)]

    [SerializeField] private TextMeshProUGUI _currentCritChanse;
    [SerializeField] private TextMeshProUGUI _nextCritChanse;

    [Space(15f)]

    [SerializeField] private TextMeshProUGUI _cost;

    private int _upgradeCost;

    private void OnEnable()
    {
        equipment.lvl = PlayerPrefs.GetInt(equipment.name, 1);
        if (equipment.lvl > 1)
            equipment.RedactStats();

        _name.SetText(equipment.name);
        _visual.sprite = equipment.visual;

        _currentLvl.SetText(equipment.lvl.ToString() + "lvl");
        _nextLvl.SetText((equipment.lvl + 1).ToString() + "lvl");

        _currentDmg.SetText(equipment.damage.ToString());
        _nextDmg.SetText((equipment.damage + equipment.damageUpgradeCoefficient).ToString());

        _currentCritChanse.SetText(equipment.critChanse.ToString() + "%");
        _nextCritChanse.SetText((equipment.critChanse + equipment.critChanseUpgradeCoefficient).ToString() + "%");

        int costPerLvl = equipment.costUpgradeCoefficient * equipment.lvl;
        _upgradeCost = costPerLvl +
            (int)(equipment.upgradeCost * (equipment.lvl - 1) * equipment.costPercentageIncrease);

        _cost.SetText("Upgrade Cost: " + _upgradeCost.ToString() + "<sprite=1>");
    }

    private void Awake() => _coins = FindObjectOfType<Coins>();

    public void UpgradeWeapon()
    {
        if (_coins.Currency >= _upgradeCost)
        {
            _coins.Currency -= _upgradeCost;

            equipment.lvl++;
            equipment.damage += equipment.damageUpgradeCoefficient;
            equipment.critChanse += equipment.critChanseUpgradeCoefficient;
            equipment.upgradeCost = _upgradeCost;

            OnUpgradingEvent?.Invoke();

            PlayerPrefs.SetInt(equipment.name, equipment.lvl);

            gameObject.SetActive(false);
        }
    }
}

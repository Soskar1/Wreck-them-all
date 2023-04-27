using UnityEngine;

[CreateAssetMenu(fileName = "new Equipment", menuName = "Equipment")]
public class Equipment : ScriptableObject
{
    public int lvl;
    public int maxLvl;

    [Space(15f)]

    public int critChanse;
    public float damage;

    [Space(15f)]

    public int upgradeCost;

    [Space(15f)]

    public float damageUpgradeCoefficient;
    public int critChanseUpgradeCoefficient;

    [Space(15f)]

    public int costUpgradeCoefficient;
    public float costPercentageIncrease;

    [Space(15f)]

    public ShopItem shopItem;
    public Sprite visual;

    public void RedactStats()
    {
        damage = damageUpgradeCoefficient * lvl;
        critChanse = critChanseUpgradeCoefficient * lvl;
    }
}

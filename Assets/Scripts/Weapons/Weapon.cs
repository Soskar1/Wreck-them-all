using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Equipment equipment;
    [SerializeField] private Upgrade _upgrade;

    [HideInInspector] public float damage;
    [HideInInspector] public int critChanse;

    private void Awake()
    {
        equipment.lvl = PlayerPrefs.GetInt(equipment.name, 1);
        if (equipment.lvl > 1)
            equipment.RedactStats();

        damage = equipment.damage;
        critChanse = equipment.critChanse;

        _upgrade.OnUpgradingEvent += IncreaseStats;
    }

    public void IncreaseStats()
    {
        damage = equipment.damage;
        critChanse = equipment.critChanse;
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "new Shop Item", menuName = "Shop Item")]
public class ShopItem : ScriptableObject
{
    public Sprite visual;
    public int price;

    public GameObject enemy;
    public Equipment equipment;

    public bool unlocked;
}

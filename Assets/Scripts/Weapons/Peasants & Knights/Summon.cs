using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Summon : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Weapon _weapon;

    [SerializeField] private GameObject _npc;
    [SerializeField] private GameObject _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    [SerializeField] private int _maxNPC;
    private int MaxNpc
    { 
        get { return _maxNPC; }
        set
        {
            _maxNPC = value;

            _counterText.SetText(_currentNPCAmount.ToString() + "/" +
                MaxNpc.ToString());
        }
    }

    private int _currentNPCAmount;
    private int CurrentNPCAmount
    {
        get { return _currentNPCAmount; }
        set
        {
            _currentNPCAmount = value;

            _counterText.SetText(_currentNPCAmount.ToString() + "/" +
                MaxNpc.ToString());
        }
    }

    [Header("\"Game\" Content")]
    [SerializeField] private ShopItem _moreNPCShopItem;
    [SerializeField] private Product _moreNPCProduct;

    private Action<InputAction.CallbackContext> handler;

    private void Awake()
    {
        string key = _moreNPCShopItem.name + "Unlocked";
        _moreNPCShopItem.unlocked = Convert.ToBoolean(PlayerPrefs.GetInt(key));

        if (_moreNPCShopItem.unlocked)
            MaxNpc *= 2;
        else
            _moreNPCProduct.OnPurchasingEvent += IncreaseMaxNpcAmount;

        handler = (InputAction.CallbackContext ctx) => SummonNPC();
    }

    private void OnEnable()
    {
        _player.controls.Player.TouchPress.started += handler;
        _counter.SetActive(true);
    }
    private void OnDisable()
    {
        _player.controls.Player.TouchPress.started -= handler;
        _counter.SetActive(false);
    }

    private void SummonNPC()
    {
        if (CurrentNPCAmount < _maxNPC)
        {
            GameObject npcInstance = Instantiate(_npc, _player.touchPos, Quaternion.identity);
            npcInstance.GetComponent<Health>().OnDeathEvent += DecreaseCurrentNpcAmount;
            NPC npc = npcInstance.GetComponent<NPC>();
            npc.damage = _weapon.damage;
            npc.critChanse = _weapon.critChanse;

            CurrentNPCAmount++;
        }
    }

    private void DecreaseCurrentNpcAmount() => CurrentNPCAmount--;
    private void IncreaseMaxNpcAmount(ShopItem shopItem) => MaxNpc *= 2;
}
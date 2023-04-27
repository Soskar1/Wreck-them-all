using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currencies : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private List<AudioClip> _sounds;

    [SerializeField] private TextMeshProUGUI _currencyAmountText;
    public Action OnCurrencyAmountChangedEvent;

    public string _currencyName;

    [HideInInspector] public bool multiplier = false;

    private int _currency;
    public int Currency
    {
        get { return _currency; }
        set
        {
            _currency = value;

            if (multiplier)
                _currency++;

            PlayerPrefs.SetInt(_currencyName, Currency);

            OnCurrencyAmountChangedEvent?.Invoke();

            _currencyAmountText.SetText(Currency.ToString());

            _source.clip = _sounds[UnityEngine.Random.Range(0, _sounds.Count)];
            _source.Play();
        }
    }
}

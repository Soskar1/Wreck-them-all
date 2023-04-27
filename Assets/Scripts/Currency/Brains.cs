using UnityEngine;

public class Brains : Currencies
{
    private void Awake()
    {
        Currency = PlayerPrefs.GetInt(_currencyName, 0);
    }
}

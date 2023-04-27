using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    { 
        coin,
        brain
    }

    public CollectibleType collectible;

    private Coins _coins;
    private Brains _brains;

    private void Awake()
    {
        switch(collectible)
        {
            case CollectibleType.coin:
                if (FindObjectOfType<Coins>() != null)
                    _coins = FindObjectOfType<Coins>();
                break;

            case CollectibleType.brain:
                if (FindObjectOfType<Brains>() != null)
                    _brains = FindObjectOfType<Brains>();
                break;
        }
    }

    private void OnDestroy()
    {
        switch (collectible)
        {
            case CollectibleType.coin:
                _coins.Currency++;
                break;

            case CollectibleType.brain:
                _brains.Currency++;
                break;
        }
    }
}

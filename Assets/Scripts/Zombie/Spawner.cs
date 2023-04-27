using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _zombies;
    [SerializeField] private List<Product> _products;
    [SerializeField] private List<ShopItem> _shopItems;

    [Header("\"Game\" Content")]
    [SerializeField] private ShopItem _moreZombiesShopItem;
    [SerializeField] private Product _moreZombiesProduct;
    [SerializeField] private float _spawnTimeDecreaseAmount;

    [SerializeField] private Vector2 _firstSpawnPoint;
    [SerializeField] private Vector2 _secondSpawnPoint;

    public float maxTime;
    private float _timer;

    [SerializeField] private int _maxEnemyAmount;
    private int _currentEnemyAmount;

    public bool canSpawn;

    private void Awake()
    {
        foreach (ShopItem shopItem in _shopItems)
        {
            string key = shopItem.name + "Unlocked";
            shopItem.unlocked = Convert.ToBoolean(PlayerPrefs.GetInt(key));

            if (shopItem.unlocked)
                AddNewZombie(shopItem);
        }

        foreach (Product product in _products)
            product.OnPurchasingEvent += AddNewZombie;

        if (_moreZombiesShopItem.unlocked)
            maxTime -= _spawnTimeDecreaseAmount;
        else
            _moreZombiesProduct.OnPurchasingEvent += DecreaseEnemySpawnTime;

        _timer = maxTime;
    }

    private void Update()
    {
        if (canSpawn)
        {
            if (_timer <= 0)
            {
                Spawn();
                _timer = maxTime;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }

    private void Spawn()
    {
        if (_currentEnemyAmount < _maxEnemyAmount)
        {
            Vector2 spawnpoint = new Vector2(UnityEngine.Random.Range(_firstSpawnPoint.x, _secondSpawnPoint.x),
                UnityEngine.Random.Range(_firstSpawnPoint.y, _secondSpawnPoint.y));

            GameObject zombie = _zombies[UnityEngine.Random.Range(0, _zombies.Count)];
            GameObject zombieInstance = Instantiate(zombie, spawnpoint, Quaternion.identity);
            zombieInstance.GetComponent<Health>().OnDeathEvent += DecreaseCurrentEnemyAmount;
            zombieInstance.GetComponent<Health>().OnDeathEvent += BossProgress.CountZombie;

            _currentEnemyAmount++;
        }
    }

    private void DecreaseCurrentEnemyAmount() => _currentEnemyAmount--;

    private void DecreaseEnemySpawnTime(ShopItem shopItem) => maxTime -= _spawnTimeDecreaseAmount;

    private void AddNewZombie(ShopItem shopItem) => _zombies.Add(shopItem.enemy);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(_firstSpawnPoint, new Vector2(_firstSpawnPoint.x, _secondSpawnPoint.y));
        Gizmos.DrawLine(new Vector2(_firstSpawnPoint.x, _secondSpawnPoint.y), _secondSpawnPoint);
        Gizmos.DrawLine(_secondSpawnPoint, new Vector2(_secondSpawnPoint.x, _firstSpawnPoint.y));
        Gizmos.DrawLine(new Vector2(_secondSpawnPoint.x, _firstSpawnPoint.y), _firstSpawnPoint);
    }
}

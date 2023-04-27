using UnityEngine;
using System.Collections.Generic;

public class BossProgress : MonoBehaviour
{
    private static ProgressBar _progressBar;

    [SerializeField] private GameObject _boss;
    [SerializeField] private List<Transform> _spawnPositions;
    [SerializeField] private List<Spawner> _spawners;
    [SerializeField] private float _changePercentage;

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioSource _evilSource;

    private int _bossAppearance = 1;

    private void Awake()
    {
        _progressBar = GetComponent<ProgressBar>();
        _progressBar.OnProgressReachedEndEvent += SpawnBoss;

        _bossAppearance = PlayerPrefs.GetInt("Boss", 1);
    }

    public static void CountZombie() => _progressBar.Current++;

    private void SpawnBoss()
    {
        GameObject bossInstance = Instantiate(_boss, _spawnPositions[Random.Range(0, _spawnPositions.Count)].position, Quaternion.identity);
        Health health = bossInstance.GetComponent<Health>();
        float maxHealth = health.currentHealth * _bossAppearance;
        health.currentHealth += maxHealth * _changePercentage;
        health.OnDeathEvent += TurnAllback;

        foreach (Spawner spawner in _spawners)
            spawner.canSpawn = false;

        _progressBar.max += (int)(_progressBar.max * _changePercentage);
        _progressBar.Current = 0;

        _source.volume = 0;
        _evilSource.volume = 0.75f;

        _bossAppearance++;
        PlayerPrefs.SetInt("Boss", _bossAppearance);
    }

    private void TurnAllback()
    {
        foreach (Spawner spawner in _spawners)
            spawner.canSpawn = true;

        _source.volume = 0.75f;
        _evilSource.volume = 0;
    }
}

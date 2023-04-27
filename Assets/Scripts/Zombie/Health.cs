using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    public float currentHealth;
    public Action OnDamageReceivedEvent;
    public Action OnDeathEvent;

    [SerializeField] private AudioSource _source;
    [SerializeField] private List<AudioClip> _hitSounds;

    private void Awake() => currentHealth = _maxHealth;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnDamageReceivedEvent?.Invoke();

        _source.clip = _hitSounds[UnityEngine.Random.Range(0, _hitSounds.Count)];
        _source.Play();

        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public void OnDestroy() => OnDeathEvent?.Invoke();
}

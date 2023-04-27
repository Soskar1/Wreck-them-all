using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Popup))]
[RequireComponent(typeof(SlowMotion))]
public class CriticalHit : MonoBehaviour
{
    [SerializeField] private float _critMultiplier;

    [SerializeField] private Popup _popup;
    [SerializeField] private SlowMotion _slowMotion;
    private Shake _shake;

    public Action OnCriticalHitEvent;

    [SerializeField] private AudioSource _source;
    [SerializeField] private List<AudioClip> _sounds;

    private void Awake() => _shake = FindObjectOfType<Shake>();

    public void Critical(Health zombie, float damage)
    {
        _slowMotion.Decelerate();
        _shake.ShakeCamera();

        _popup.SpawnPopup("CRITICAL HIT!", zombie.transform.position);

        OnCriticalHitEvent?.Invoke();

        _source.clip = _sounds[UnityEngine.Random.Range(0, _sounds.Count)];
        _source.Play();

        zombie.TakeDamage(damage * _critMultiplier);
    }

    public bool CriticalHitCheck(int critChance)
    {
        if (UnityEngine.Random.Range(0, 100) < critChance)
            return true;

        return false;
    }
}

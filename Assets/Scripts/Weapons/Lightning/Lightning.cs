using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lightning : MonoBehaviour
{
    private Player _player;
    private Weapon _weapon;
    private CriticalHit _critical;

    private ParticleSystem _particleSystem;

    [SerializeField] private List<AudioClip> _sounds;
    private AudioSource _source;

    [SerializeField] private GameObject _explosion;

    private static Action<InputAction.CallbackContext> handler;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();

        _weapon = GetComponent<Weapon>();
        _critical = GetComponent<CriticalHit>();

        _particleSystem = GetComponent<ParticleSystem>();
        _source = GetComponent<AudioSource>();

        handler = (InputAction.CallbackContext ctx) => Attack();
    }

    private void OnEnable() => _player.controls.Player.TouchPress.started += handler;
    private void OnDisable() => _player.controls.Player.TouchPress.started -= handler;

    private void Attack()
    {
        transform.position = new Vector2(_player.touchPos.x, transform.position.y);

        _particleSystem.Play();

        _source.clip = _sounds[UnityEngine.Random.Range(0, _sounds.Count)];
        _source.Play();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.GetComponent<Health>() != null)
        {
            Instantiate(_explosion, other.transform.position, Quaternion.identity);

            if (_critical.CriticalHitCheck(_weapon.critChanse))
                _critical.Critical(other.GetComponent<Health>(), _weapon.damage);

            _particleSystem.Stop();
        }
    }
}

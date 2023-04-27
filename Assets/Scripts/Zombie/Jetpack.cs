using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [SerializeField] private Health _health;
    private Player _player;

    [SerializeField] private Rigidbody2D _rb2d;


    [SerializeField] private float _power;
    [SerializeField] private float _maxTime;
    private float _timer;

    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _fire;

    private bool _needToFly;
    private Vector2 _direction;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();

        _health.OnDamageReceivedEvent = ActivateJetpack;
        _health.OnDeathEvent = Explode;

        _timer = _maxTime;
    }

    private void FixedUpdate()
    {
        if (_needToFly)
        {
            if (_timer <= 0)
            {
                _fire.SetActive(false);
                _needToFly = false;

                _timer = _maxTime;
            }
            else
            {
                _rb2d.AddForce(_direction * _power);

                _timer -= Time.fixedDeltaTime;
            }
        }
    }

    private void ActivateJetpack()
    {
        var heading = _player.transform.position - transform.position;
        var distance = heading.magnitude;
        _direction = heading / distance;

        _fire.SetActive(true);
        _needToFly = true;
    }

    private void Explode() => Instantiate(_explosion, transform.position, Quaternion.identity);
}

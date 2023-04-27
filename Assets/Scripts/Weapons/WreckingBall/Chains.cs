using UnityEngine;

public class Chains : MonoBehaviour
{
    private Player _player;

    private Rigidbody2D _rb2d;

    [SerializeField] private float _force;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() => _rb2d.velocity = (_player.touchPos - (Vector2)transform.position)
        * _force * Time.fixedDeltaTime;
}

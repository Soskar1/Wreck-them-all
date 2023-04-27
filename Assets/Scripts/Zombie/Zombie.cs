using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Header("Health & Damage")]
    [SerializeField] private Health _health;
    [SerializeField] private float damage;

    [SerializeField] private GameObject _bloodParticle;

    [Header("Coin")]
    [SerializeField] private GameObject _coin;
    [SerializeField] private int _coinAmount;

    [Header("Brain")]
    [SerializeField] private GameObject _brain;
    [SerializeField] private float _brainDropChanse;

    [Header("Collectible Drop")]
    [SerializeField] private float _minRepulsiveForce;
    [SerializeField] private float _maxRepulsiveForce;

    private void Awake() => _health.OnDeathEvent += Death;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
    }

    private void Death()
    {
        Instantiate(_bloodParticle, transform.position, Quaternion.identity);

        if (_coinAmount == 1)
        {
            DropCollectible(_coin);
        }
        else
        {
            while (_coinAmount > 0)
            {
                DropCollectible(_coin);

                _coinAmount--;
            }
        }

        if (Random.Range(0.01f, 100) <= _brainDropChanse)
            DropCollectible(_brain);
    }

    private void DropCollectible(GameObject collectible)
    {
        GameObject coinInstance = Instantiate(collectible, transform.position, Quaternion.identity);

        Vector2 force = new Vector2(Random.Range(_minRepulsiveForce, _maxRepulsiveForce),
            Random.Range(0, _maxRepulsiveForce));
        coinInstance.GetComponent<Rigidbody2D>().AddForce(force);
    }
}

using UnityEngine;

public class NPC : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public int critChanse;

    [SerializeField] private Health _health;
    [SerializeField] private CriticalHit _criticalHit;

    [SerializeField] private GameObject _bloodParticles;

    private void Awake() => _health.OnDeathEvent += Death;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            Health health = collision.gameObject.GetComponent<Health>();

            if (_criticalHit.CriticalHitCheck(critChanse))
                _criticalHit.Critical(health, damage);
            else
                health.TakeDamage(damage);
        }
    }

    private void Death() => Instantiate(_bloodParticles, transform.position, Quaternion.identity);
}

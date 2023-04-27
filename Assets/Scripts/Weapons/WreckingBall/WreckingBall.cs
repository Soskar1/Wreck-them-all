using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    private Weapon _weapon;
    private CriticalHit _criticalHit;

    private void Awake()
    {
        _weapon = GetComponentInParent<Weapon>();
        _criticalHit = GetComponent<CriticalHit>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            Health health = collision.gameObject.GetComponent<Health>();

            if (_criticalHit.CriticalHitCheck(_weapon.critChanse))
                _criticalHit.Critical(health, _weapon.damage);
            else
                health.TakeDamage(_weapon.damage);
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _damage;

    [SerializeField] private float _radius;
    [SerializeField] private int _power;
    [SerializeField] private LayerMask _whomToPush;

    private Collider2D[] _entities;
    private Vector2 _direction;

    [SerializeField] private List<AudioClip> _sounds;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = _sounds[Random.Range(0, _sounds.Count)];
        _source.Play();
    }

    private void Start()
    {
        _entities = Physics2D.OverlapCircleAll(transform.position, _radius, _whomToPush);
        foreach(Collider2D entity in _entities)
        {
            if (entity.GetComponent<Rigidbody2D>() != null)
            {
                if (entity.GetComponent<Health>() != null)
                    entity.GetComponent<Health>().TakeDamage(_damage);

                _direction = transform.position - entity.transform.position;
                entity.GetComponent<Rigidbody2D>().AddForce(_direction * _power, ForceMode2D.Impulse);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float theta = 0;
        float x = _radius * Mathf.Cos(theta);
        float y = _radius * Mathf.Sin(theta);
        Vector3 pos = transform.position + new Vector3(x, y, 0);
        Vector3 newPos = pos;
        Vector3 lastPos = pos;
        for (theta = 0.1f; theta < Mathf.PI * 2; theta += 0.1f)
        {
            x = _radius * Mathf.Cos(theta);
            y = _radius * Mathf.Sin(theta);
            newPos = transform.position + new Vector3(x, y, 0);
            Gizmos.DrawLine(pos, newPos);
            pos = newPos;
        }
        Gizmos.DrawLine(pos, lastPos);
    }
}

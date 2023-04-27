using UnityEngine;

public class Attraction : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;

    private Transform _target;

    private Rigidbody2D _rb2d;
    private GroundCheck _groundCheck;

    private bool _canAttract;

    private void Awake()
    {
        _target = FindObjectOfType<Player>().transform;
        _rb2d = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponent<GroundCheck>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _target.position) < _distance && !_canAttract)
            if (_groundCheck.Grounded())
                _canAttract = true;
    }

    private void FixedUpdate()
    {
        if (_canAttract)
        {
            var heading = _target.position - transform.position;
            var distance = heading.magnitude;
            Vector2 direction = heading / distance;
            _rb2d.AddForce(direction * _speed * Time.fixedDeltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        float theta = 0;
        float x = _distance * Mathf.Cos(theta);
        float y = _distance * Mathf.Sin(theta);
        Vector3 pos = transform.position + new Vector3(x, y, 0);
        Vector3 newPos = pos;
        Vector3 lastPos = pos;
        for (theta = 0.1f; theta < Mathf.PI * 2; theta += 0.1f)
        {
            x = _distance * Mathf.Cos(theta);
            y = _distance * Mathf.Sin(theta);
            newPos = transform.position + new Vector3(x, y, 0);
            Gizmos.DrawLine(pos, newPos);
            pos = newPos;
        }
        Gizmos.DrawLine(pos, lastPos);
    }
}

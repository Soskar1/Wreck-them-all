using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2d;

    [SerializeField] private GroundCheck _groundCheck;

    [SerializeField] private float _minForce;
    [SerializeField] private float _maxForce;

    private void FixedUpdate()
    {
        if (_groundCheck.Grounded())
            Jump();
    }

    private void Jump()
    {
        Vector2 direction = Random.insideUnitCircle.normalized;
        float force = Random.Range(_minForce, _maxForce);
        _rb2d.AddForce(direction * force * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
}

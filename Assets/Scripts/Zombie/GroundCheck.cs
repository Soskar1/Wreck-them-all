using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _whatIsGround;

    public bool Grounded()
    {
        Collider2D[] _overlapInfo = Physics2D.OverlapCircleAll(_groundCheck.position, _radius, _whatIsGround);

        foreach (Collider2D collider in _overlapInfo)
            if (collider.gameObject != gameObject)
                return true;

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        float theta = 0;
        float x = _radius * Mathf.Cos(theta);
        float y = _radius * Mathf.Sin(theta);
        Vector3 pos = _groundCheck.position + new Vector3(x, y, 0);
        Vector3 newPos = pos;
        Vector3 lastPos = pos;
        for (theta = 0.1f; theta < Mathf.PI * 2; theta += 0.1f)
        {
            x = _radius * Mathf.Cos(theta);
            y = _radius * Mathf.Sin(theta);
            newPos = _groundCheck.position + new Vector3(x, y, 0);
            Gizmos.DrawLine(pos, newPos);
            pos = newPos;
        }
        Gizmos.DrawLine(pos, lastPos);
    }
}

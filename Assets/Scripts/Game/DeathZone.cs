using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private Transform _safeZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
            collision.gameObject.transform.position = _safeZone.position;
    }
}

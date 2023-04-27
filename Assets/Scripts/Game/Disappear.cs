using UnityEngine;

public class Disappear : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private void Awake() => Destroy(gameObject, _lifeTime);
}

using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private CriticalHit _criticalHit;
    [SerializeField] private SlowMotion _slowMotion;

    [SerializeField] private float _lifeTime;
    [SerializeField] private float _delay;
    private float _timer;

    [SerializeField] private GameObject _ghost;
    [HideInInspector] public bool ghostEffect;

    private void Awake()
    {
        _criticalHit.OnCriticalHitEvent += ActivateGhost;
        _slowMotion.OnSlowMotionDisabledEvent += DeactivateGhost;

        _timer = _delay;
    }

    private void Update()
    {
        if (ghostEffect)
        {
            if (_timer < 0)
            {
                GameObject ghostInstance = Instantiate(_ghost, transform.position, transform.rotation);
                Destroy(ghostInstance, _lifeTime);

                _timer = _delay;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }

    private void ActivateGhost() => ghostEffect = true;
    private void DeactivateGhost() => ghostEffect = false;
}

using System.Collections;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private Material _flashMaterial;
    [SerializeField] private float _duration;

    [SerializeField] private SpriteRenderer _visual;
    private Material _originalMaterial;
    private Coroutine _flashRoutine;

    private void Start()
    {
        _originalMaterial = _visual.material;

        _health.OnDamageReceivedEvent += ActivateFlash;
    }

    public void ActivateFlash()
    {
        if (_flashRoutine != null)
            StopCoroutine(_flashRoutine);

        _flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        _visual.material = _flashMaterial;

        yield return new WaitForSeconds(_duration);

        _visual.material = _originalMaterial;
        _flashRoutine = null;
    }
}

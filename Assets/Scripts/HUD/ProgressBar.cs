using UnityEngine;
using UnityEngine.UI;
using System;

public class ProgressBar : MonoBehaviour
{
    public Action OnProgressReachedEndEvent;

    public int min;
    public int max;

    private int _current;
    public int Current
    {
        get { return _current; }
        set
        {
            _current = value;
            SetFill();

            if (_current >= max)
                OnProgressReachedEndEvent?.Invoke();
        }
    }

    [SerializeField] private Image _fill;

    private void SetFill()
    {
        float currentOffset = Current - min;
        float maxOffset = max - min;
        float fillAmount = currentOffset / maxOffset;
        _fill.fillAmount = fillAmount;
    }
}

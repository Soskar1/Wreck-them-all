using System;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float maxTime;
    private float _timer;

    private const float DEFAULT_GAME_TIME_SPEED = 1;
    [SerializeField] [Range(0.1f, 1)] public float deceleration;

    public Action OnSlowMotionDisabledEvent;

    private void Awake() => _timer = maxTime;

    private void Update()
    {
        if (Time.timeScale < DEFAULT_GAME_TIME_SPEED)
        {
            if (_timer < 0)
            {
                OnSlowMotionDisabledEvent?.Invoke();

                Time.timeScale = DEFAULT_GAME_TIME_SPEED;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }

    public void Decelerate()
    {
        Time.timeScale = deceleration;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        _timer = maxTime;
    }
}

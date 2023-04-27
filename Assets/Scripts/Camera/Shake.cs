using Cinemachine;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] private float _intensity;
    [SerializeField] private float _time;

    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

    private float _startingIntensity;
    private float _timerTotal;
    private float _timer;

    private void Awake()
    { 
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

        _cinemachineBasicMultiChannelPerlin = 
            _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;

            float t = (1 - _timer / _timerTotal);

            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =
                Mathf.Lerp(_startingIntensity, 0f, t);
        }
    }

    public void ShakeCamera()
    {
        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = _intensity;
        _startingIntensity = _time;
        _timer = _time;
    }
}

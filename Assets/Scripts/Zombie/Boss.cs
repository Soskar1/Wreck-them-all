using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Health _health;
    [HideInInspector] public int appearance;

    private void Awake()
    {
        _health.currentHealth *= appearance;
    }
}

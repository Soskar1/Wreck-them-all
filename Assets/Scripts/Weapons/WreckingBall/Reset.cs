using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private List<Transform> _wreckingBall;
    [SerializeField] private List<Vector3> _originalPositions;

    private void OnEnable()
    {
        transform.position = Vector2.zero;

        for (int index = 0; index < _wreckingBall.Count; index++)
        {
            _wreckingBall[index].rotation = Quaternion.Euler(0, 0, 0);
            _wreckingBall[index].position = _originalPositions[index];
        }
    }
}

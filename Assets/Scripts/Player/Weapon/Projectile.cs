using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _currentPosition;
    private Vector3 _targetPosition;

    public void Fire(Vector3 from, Vector3 target)
    {
        _currentPosition = from;
        _targetPosition = target;
    }

    private void Fly()
    {
        Vector3.MoveTowards(_currentPosition, _targetPosition, _speed * Time.deltaTime);
    }
}

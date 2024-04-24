using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Transform _playerModel;
    [SerializeField] private float _speed;

    public void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion from = _playerModel.rotation;
            Quaternion to = Quaternion.LookRotation(direction, Vector3.up);
            _playerModel.rotation = Quaternion.RotateTowards(from, to, _speed * Time.deltaTime);
        }
    }
}
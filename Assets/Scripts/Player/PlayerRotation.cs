using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Enemy _target;

    public void LookAtTarget(Enemy enemy)
    {
        if (enemy != null)
        {
            _target = enemy;
            Vector3 direction = _target.transform.position;
            direction.y = 1f;
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _speed * Time.deltaTime);
        }
    }

    public void LookAtDirection(Vector3 direction)
    {
        if (_target == null)
        {
            transform.LookAt(direction);
            direction.y = 1f;
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _speed * Time.deltaTime);
        }
    }
}
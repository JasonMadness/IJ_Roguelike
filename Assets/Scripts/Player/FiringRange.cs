using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringRange : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private GameObject _view;
    [SerializeField] private Collider _collider;
    [SerializeField] private float _coefficient;

    public event Action<Enemy> EnemyEnterFiringRange;
    public event Action<Enemy> EnemyLeftFiringRange;
    
    private void Start()
    {
        SetLocalScale();
    }

    public void ChangeDistance(float distance)
    {
        _distance = distance;
        SetLocalScale();
    }

    private void SetLocalScale()
    {
        float distance = _distance * _coefficient;
        _view.transform.localScale = new Vector3(distance, distance, _view.transform.localScale.z);
        _collider.transform.localScale = new Vector3(_distance, _distance, _distance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            EnemyEnterFiringRange?.Invoke(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            EnemyLeftFiringRange?.Invoke(enemy);
        }
    }

    private void Update()
    {
        SetLocalScale();
        _view.transform.position = transform.position;
    }
}

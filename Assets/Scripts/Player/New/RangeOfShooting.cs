using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RangeOfShooting : MonoBehaviour
{
    private List<Enemy> _enemiesInRange = new List<Enemy>();
    private Enemy _nearestEnemy;

    public event Action<Enemy> NearestEnemyFound; 

    private void FindNearestEnemy()
    {
        _nearestEnemy = _enemiesInRange.FirstOrDefault();
        
        if (_nearestEnemy != null)
        {
            float shortestRange = Vector3.Distance(_nearestEnemy.transform.position, transform.position);

            foreach (Enemy enemy in _enemiesInRange)
            {
                float distanceToEnemy = Vector3.Distance(enemy.transform.position, transform.position);

                if (distanceToEnemy < shortestRange)
                {
                    shortestRange = distanceToEnemy;
                    _nearestEnemy = enemy;
                }
            }

            NearestEnemyFound?.Invoke(_nearestEnemy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemiesInRange.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemiesInRange.Remove(enemy);
        }
    }

    private void Update()
    {
        if (_enemiesInRange.Count > 0)
        {
            FindNearestEnemy();
        }
    }
}

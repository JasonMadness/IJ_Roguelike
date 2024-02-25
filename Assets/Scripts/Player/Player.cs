using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    private List<Enemy> _enemiesInRange = new List<Enemy>();
    private Enemy _nearestEnemy;

    public void OnFiringRangeEnter(Enemy enemy)
    {
        _enemiesInRange.Add(enemy);
    }

    public void OnFiringRangeExit(Enemy enemy)
    {
        _enemiesInRange.Remove(enemy);
    }

    private bool HasEnemiesInRange()
    {
        return _enemiesInRange.Count > 0;
    }

    private void ChangeWeaponTarget(Enemy enemy)
    {
        _weapon.SetTarget(enemy);
    }

    private void FindNearestEnemy()
    {
        _nearestEnemy = _enemiesInRange.First();
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

        ChangeWeaponTarget(_nearestEnemy);
    }

    private void ClearTarget()
    {
        _weapon.ClearTarget();
    }

    private void Update()
    {
        if (HasEnemiesInRange())
        {
            FindNearestEnemy();
        }
        else
        {
            ClearTarget();
        }
    }
}
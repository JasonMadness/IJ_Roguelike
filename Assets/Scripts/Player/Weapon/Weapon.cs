using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _shotDelay;

    public void Shoot(Enemy enemy)
    {
        _projectile.Fire(transform.position, enemy.transform.position);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _shotDelay;

    private Enemy _target;
    private float _weaponCooldown;

    private void Start()
    {
        _weaponCooldown = _shotDelay;
    }

    public void SetTarget(Enemy enemy)
    {
        _target = enemy;
        
        //Debug.Log("Целью оружия назначен: " + enemy.gameObject.name + " по координатам: " + enemy.transform.position);
    }

    public void ClearTarget()
    {
        _target = null;
    }

    private void TryShoot()
    {
        if (_weaponCooldown <= 0 && _target != null)
        {
            Projectile projectile = Instantiate(_projectile);
            projectile.transform.position = transform.position;
            projectile.Fire(_target.transform.position);
            _weaponCooldown = _shotDelay;
        }
    }

    private void Update()
    {
        _weaponCooldown -= Time.deltaTime;
        TryShoot();
        
        /*if (_target == null)
            Debug.Log("На данный момент у оружия нет цели");
        else
            Debug.Log("Целью оружия назначен: " + _target.gameObject.name + " по координатам: " + _target.transform.position);
            */
    }
}
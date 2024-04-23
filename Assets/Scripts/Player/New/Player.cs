using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Input _input;
    [SerializeField] private Movement _movement;
    [SerializeField] private Rotation _rotation;
    [SerializeField] private RangeOfShooting _rangeOfShooting;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private PlayerAnimation _animation;

    //---------------------------
    private Enemy _nearestEnemy;
    //---------------------------
    
    public void OnNearestEnemyFound(Enemy enemy)
    {
        _nearestEnemy = enemy;
        _weapon.SetTarget(_nearestEnemy);
        _weapon.TryShoot();
        // сделать вращение к врагу, стрельбу во врага и придумать вращение в апдейте
    }

    private void Update()
    {
        Vector3 direction = _input.GetDirection();
        _animation.Animate(direction);
        _movement.Move(direction);
        _rotation.Rotate(direction);
    }
}

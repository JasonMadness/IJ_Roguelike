using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subscriber : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private FiringRange _firingRange;
    
    private void OnEnable()
    {
        _firingRange.EnemyEnterFiringRange += _player.OnFiringRangeEnter;
        _firingRange.EnemyLeftFiringRange += _player.OnFiringRangeExit;
    }

    private void OnDisable()
    {
        _firingRange.EnemyEnterFiringRange -= _player.OnFiringRangeEnter;
        _firingRange.EnemyLeftFiringRange -= _player.OnFiringRangeExit;
    }
}

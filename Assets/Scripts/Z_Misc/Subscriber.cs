using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subscriber : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private RangeOfShooting _rangeOfShooting;

    private void OnEnable()
    {
        _rangeOfShooting.NearestEnemyFound += _player.OnNearestEnemyFound;
    }
}

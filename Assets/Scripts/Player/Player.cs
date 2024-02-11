using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Enemy> _enemiesInRange;

    public void OnFiringRangeEnter(Enemy enemy)
    {
        _enemiesInRange.Add(enemy);
        Debug.Log($"Enemy: {enemy.gameObject.transform.position} +++ENTER+++ range");
    }

    public void OnFiringRangeExit(Enemy enemy)
    {
        _enemiesInRange.Remove(enemy);
        Debug.Log($"Enemy: {enemy.gameObject.transform.position} ---LEFT--- range");
    }
}

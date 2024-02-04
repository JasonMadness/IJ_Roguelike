using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Boundaries _boundaries;
    [SerializeField] private int _count;
    [SerializeField] private float _delay;

    private Vector3 _borders;

    private void Start()
    {
        _borders = _boundaries.Get();
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds delay = new(_delay);

        for (int i = 0; i < _count; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(_prefab, spawnPosition, Quaternion.identity);
            yield return delay;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomPosition = new Vector3();
        Vector3 boundaries = _boundaries.Get();
        float randomSide = Random.Range(1, 100);

        if (randomSide < 25)
        {
            randomPosition.x = -boundaries.x;
            randomPosition.z = Random.Range(-boundaries.z, boundaries.z);
        }
        else if (randomSide < 50)
        {
            randomPosition.z = -boundaries.z;
            randomPosition.x = Random.Range(-boundaries.x, boundaries.x);
        }
        else if (randomSide < 75)
        {
            randomPosition.x = boundaries.x;
            randomPosition.z = Random.Range(-boundaries.z, boundaries.z);
        }
        else
        {
            randomPosition.z = boundaries.z;
            randomPosition.x = Random.Range(-boundaries.x, boundaries.x);
        }

        //костыль
        randomPosition.y = 1f;

        return randomPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Spawn());
        }
    }
}
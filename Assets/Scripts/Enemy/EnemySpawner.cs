using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Boundaries _boundaries;
    [SerializeField] private int _count;
    [SerializeField] private float _delay;

    private float _floorOffset;

    private IEnumerator Spawn()
    {
        WaitForSeconds delay = new(_delay);

        for (int i = 0; i < _count; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject newEnemy = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().Initialize(_player);
            yield return delay;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomPosition = new Vector3();
        Vector3 boundaries = _boundaries.Get();
        float randomSide = Random.Range(0, 100);

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

        randomPosition.y = _floorOffset;
        return randomPosition;
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Spawn());
        }
    }
}
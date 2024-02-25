using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    private Transform _target;
    private NavMeshAgent _agent;

    public event Action<Enemy> Killed;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Initialize(Transform player)
    {
        _target = player;
    }

    public void TakeDamage(float damage)
    {
        if (damage > _health)
        {
            damage = _health;
        }

        _health -= damage;

        if (_health == 0)
        {
            Killed?.Invoke(this);
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        _agent.SetDestination(_target.position);
    }
}

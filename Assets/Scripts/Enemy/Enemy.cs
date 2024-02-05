using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform _target;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Initialize(Transform player)
    {
        _target = player;
    }
    
    private void Update()
    {
        _agent.SetDestination(_target.position);
    }
}

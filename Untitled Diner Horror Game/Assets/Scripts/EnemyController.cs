using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform player;  
    public float randomMoveRadius = 5f;
    public float detectionRange = 10f;
    private bool isChasing = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            StartChasing();
        }
        else if (isChasing)
        {
            StopChasing();
        }

        if (!isChasing && navMeshAgent.remainingDistance < 0.5f)
        {
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomDestination = transform.position + Random.insideUnitSphere * randomMoveRadius;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDestination, out hit, randomMoveRadius, 1);
        navMeshAgent.SetDestination(hit.position);
    }

    bool CanSeePlayer()
    {
        if (player == null)
        {
            return false;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer < detectionRange;
    }

    void StartChasing()
    {
        isChasing = true;
        navMeshAgent.SetDestination(player.position);
    }

    void StopChasing()
    {
        isChasing = false;
        SetRandomDestination();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetRandomDestination(); // Set an initial destination
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            SetRandomDestination(); // Set a new destination when reached
        }
    }

    void SetRandomDestination()
    {
        // Set a random destination within the NavMesh bounds
        Vector3 randomDestination = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
        navMeshAgent.SetDestination(randomDestination);
    }
}
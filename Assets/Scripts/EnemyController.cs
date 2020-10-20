using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    NavMeshAgent nvAgent;
    Transform finishPos;

    void Start()
    {
        finishPos = GameObject.Find("Finish").transform;
        nvAgent = GetComponent<NavMeshAgent>();
        nvAgent.SetDestination(finishPos.position);
    }
}

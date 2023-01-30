using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class RobotBehavior : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        _agent.SetDestination(_player.transform.position);
    }
}

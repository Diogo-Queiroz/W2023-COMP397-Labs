using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private GameObject player;
    [SerializeField] private int currentPath;
    private bool isChasingPlayer = false;
    public List<GameObject> tileRobotPath;
    
    // Start is called before the first frame update
    void Start()
    {
        currentPath = 0;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent.speed = Random.Range(2, 7);
        if (tileRobotPath.Count <= 0)
        {
            agent.SetDestination(player.transform.position);
            isChasingPlayer = true;
        }
        else
        {
            agent.SetDestination(tileRobotPath[currentPath].transform.position);
            isChasingPlayer = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasingPlayer) { return; }

        var close = Vector3.Distance(transform.position,
            tileRobotPath[currentPath].transform.position);

        if (close <= 1.5f)
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        currentPath++;
        if (currentPath >= tileRobotPath.Count)
        {
            currentPath = 0;
        }
        agent.SetDestination(tileRobotPath[currentPath].transform.position);
    }
}

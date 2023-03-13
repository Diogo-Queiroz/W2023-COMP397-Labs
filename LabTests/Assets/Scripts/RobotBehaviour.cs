using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private GameObject player;
    [SerializeField] private int currentPath; 
    
    public List<GameObject> tileRobotPath;
    
    // Start is called before the first frame update
    void Start()
    {
        currentPath = 0;
        agent = GetComponent<NavMeshAgent>();
        //player = GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(tileRobotPath[currentPath].transform.position);
        agent.speed = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        var close = Vector3.Distance(transform.position, tileRobotPath[currentPath].transform.position);
        Debug.Log($"Close = {close}");
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

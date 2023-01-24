using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<NavMeshSurface> maze;
    
    void Start()
    {
        foreach (NavMeshSurface tiles in maze)
        {
            tiles.BuildNavMesh();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<NavMeshSurface> _maze;
    [SerializeField] private List<GameObject> _robots;

    private void Start()
    {
        foreach (var tiles in _maze)
        {
            tiles.BuildNavMesh();
        }
        foreach (var robot in _robots)
        {
            robot.SetActive(true);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RobotSpawner : MonoBehaviour
{
    public GameObject robotPrefab;
    public int robotSpawnChance = 0;
    public void SpawnRobots(List<GameObject> activeMazeTiles, Dificulty difficulty)
    {
        robotSpawnChance = difficulty switch
        {
            Dificulty.Easy => 25,
            Dificulty.Normal => 50,
            Dificulty.Hard => 75,
            Dificulty.VeryHard => 100,
            _ => throw new ArgumentOutOfRangeException()
        };
        
        for (int i = 0; i < activeMazeTiles.Count; i++)
        {
            var robotSpawn = activeMazeTiles[i].transform.GetChild(
                activeMazeTiles[i].transform.childCount - 1);
            var randomChance = Random.Range(0, 101);
            
            if (robotSpawn.gameObject.tag.Equals("EnemySpawn") && robotSpawnChance >= randomChance)
            {
                var robot = Instantiate(robotPrefab,
                    robotSpawn.position, Quaternion.identity);
                robot.transform.parent = this.transform;
                for (int j = 0; j < robotSpawn.childCount; j++)
                {
                    if (robotSpawn.GetChild(j).CompareTag("RobotPath"))
                    {
                        robot.GetComponent<RobotBehaviour>().tileRobotPath.Add(
                            robotSpawn.GetChild(j).gameObject);
                    }
                }
            }
            
        }
    }
}

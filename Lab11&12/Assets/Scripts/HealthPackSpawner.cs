using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    public List<GameObject> healthPackLocations;
    public GameObject healthPackPrefab;

    private void Start()
    {
        var randomHealthPackLocation = Random.Range(0, healthPackLocations.Count);
        var healthPack = Instantiate(healthPackPrefab, new Vector3(
                healthPackLocations[randomHealthPackLocation].transform.position.x, 
                1,
                healthPackLocations[randomHealthPackLocation].transform.position.z), 
            Quaternion.Euler(0, 0, 0),
            healthPackLocations[randomHealthPackLocation].transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSensor : MonoBehaviour
{

    [Header("Raycasting")]
    [SerializeField] private Color tintColor = Color.green;
    [SerializeField] private Color tintColorForRaycastAll = Color.yellow;
    [SerializeField] private Vector3 origin;
    [SerializeField] private Vector3 direction;

    private void Update()
    {
        RaycastSingle();        
    }
    private void RaycastSingle()
    {
        origin = transform.position - new Vector3(0, 0.5f, 0);
        direction = transform.forward;

        Debug.DrawLine(origin, direction * 5f, Color.red);
        Ray ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log($"Hitting {hit.collider.gameObject.name}");
        }
    }
}

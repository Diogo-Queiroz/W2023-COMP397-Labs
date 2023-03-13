using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 
            transform.position.y, player.transform.position.z);
        transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, 
            player.transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}

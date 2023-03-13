using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public void Setup(string name)
    {
        Debug.Log("TileGenerator -> " + name);
        Factory.TileFactory.GetTile(name).Create();
    }
}

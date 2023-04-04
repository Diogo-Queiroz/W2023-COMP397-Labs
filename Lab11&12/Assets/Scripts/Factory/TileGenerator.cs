using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory;

public class TileGenerator : MonoBehaviour
{
    public void Setup(string name)
    {
        Debug.Log($"TileGenerator Setup {name}");
        TileFactory.GetTile(name).Create();
    }
}

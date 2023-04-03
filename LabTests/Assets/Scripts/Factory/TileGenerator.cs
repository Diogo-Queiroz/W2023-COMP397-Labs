using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public void Setup(string name)
    {
        Debug.Log("TileGenerator -> " + name);
        Factory.TileFactory.GetTile(name).Create();
    }
}

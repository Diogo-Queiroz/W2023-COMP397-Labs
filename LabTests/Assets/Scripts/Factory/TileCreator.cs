using Factory;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileCreator : MonoBehaviour
{
    [SerializeField] private TileGenerator tilePrefab;

    public int width;
    public int length;
    public IEnumerable<string> tilePrefabsNames;
    public List<TileGenerator> activeTiles;
    public List<TileGenerator> factoryOfTiles;

    private void OnEnable()
    {
        tilePrefabsNames = TileFactory.GetTileNames();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                int randomTileIndex = Random.Range(0, TileFactory.GetTileCount());
                Vector3 randomTilePosition = new Vector3(i * 16, 0.0f, j * 16);
                float randomTileRotation = Random.Range(0, 4) * 90.0f;
                TileGenerator randomTile = Instantiate(tilePrefab,
                    randomTilePosition, Quaternion.Euler(0, randomTileRotation, 0));
                randomTile.transform.parent = transform;
                randomTile.gameObject.name = tilePrefabsNames.ElementAt(randomTileIndex);
                randomTile.Setup(tilePrefabsNames.ElementAt(randomTileIndex));
                activeTiles.Add(randomTile);
            }
        }
    }
}

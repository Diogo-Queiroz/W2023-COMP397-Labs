using Factory;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class TileCreator : MonoBehaviour
{
    [SerializeField] private TileGenerator tileGenerator;

    public int width;
    public int length;
    public IEnumerable<string> tileCreatorNames;
    public List<TileGenerator> factoryOfTiles;
    public List<TileGenerator> activeTiles;

    private void OnEnable()
    {
        tileCreatorNames = TileFactory.GetTileNames();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                var randomTileIndex = Random.Range(0, TileFactory.GetTileCount());
                var randomTilePosition = new Vector3(i * 16, 0.0f, j * 16);
                var randomTileRotation = Random.Range(0, 4) * 90.0f;
                var randomTile = Instantiate(tileGenerator,
                    randomTilePosition, Quaternion.Euler(0, randomTileRotation, 0));
                randomTile.transform.parent = transform;
                randomTile.gameObject.name = tileCreatorNames.ElementAt(randomTileIndex);
                randomTile.Setup(tileCreatorNames.ElementAt(randomTileIndex));
                activeTiles.Add(randomTile);
            }
        }
    }
}

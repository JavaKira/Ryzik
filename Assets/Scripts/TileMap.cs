using System;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] private float tilesGap;
    
    private Tile[][] _tiles;
    private void Start()
    {
        DebugWorld();
        Build();
    }

    // after i made load from file
    private void DebugWorld()
    {
        _tiles = new Tile[10][];

        for (var i = 0; i < _tiles.Length; i++)
        {
            _tiles[i] = new Tile[10];
            
            for (var x = 0; x < _tiles[i].Length;x++)
            {
                var tile = Tile.GetByName("WoodenPlankTile");
                _tiles[i][x] = tile;
            }
        }
    }

    private void Build()
    {
        for (int x = 0; x < _tiles.Length; x++)
        {
            for (int y = 0; y < _tiles[x].Length; y++)
            {
                var transform1 = transform;
                Instantiate(
                    _tiles[x][y],
                    transform1.position + new Vector3(x * tilesGap, y * tilesGap, 0),
                    Quaternion.identity, 
                    transform1
                );
            }
        }
    }
}
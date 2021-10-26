using System;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] private float tilesGap;
    [SerializeField] private TileBehaviour tilePrefab;

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
                var tile = new Tile
                {
                    Floor = Floor.GetByName("Grass"),
                    InTilemapPosition = new Vector3(i * tilesGap, x * tilesGap)
                };
                _tiles[i][x] = tile;
            }
        }
    }

    private void Build()
    {
        foreach (var t in _tiles)
        {
            foreach (var t1 in t)
            {
                AddTile(t1);
            }
        }
    }

    private void AddTile(Tile tile)
    {
        var createdTile = Instantiate(
            tilePrefab,
            new Vector2(tile.InTilemapPosition.x, tile.InTilemapPosition.y),
            Quaternion.identity,
            transform
        );

        createdTile.Tile = tile;
        createdTile.Tile.Block = tile.Block;
    }
}
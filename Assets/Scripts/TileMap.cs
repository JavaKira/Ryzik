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
        _tiles = new Tile[100][];

        for (var i = 0; i < _tiles.Length; i++)
        {
            _tiles[i] = new Tile[100];
            
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

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                _tiles[x + 30][y + 30].Block = Block.GetByName("WoodenPlank");
            }
        }
        
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                _tiles[x + 31][y + 31].Block = Block.GetAir();
                _tiles[x + 31][y + 31].Floor = Floor.GetByName("WoodenPlank");
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

    public Tile GetTile(int x, int y)
    {
        return _tiles[x][y];
    }

    public Tile GetTileByWorldPosition(int worldX, int worldY)
    {
        return GetTile((int) (worldX / tilesGap), (int) (worldY / tilesGap));
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
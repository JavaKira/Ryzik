using System;
using System.Drawing;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] private float tilesGap;
    [SerializeField] private TileBehaviour tilePrefab;

    private Tile[][] _tiles;
    private int _width, _height;

    public Vector2 Size => new Vector2(_width, _height);

    private void Start()
    {
        DebugWorld();
        Build();
    }

    // after i made load from file
    private void DebugWorld()
    {
        _width = 100;
        _height = 100;
        _tiles = new Tile[_width][];

        for (var x = 0; x < _width; x++)
        {
            _tiles[x] = new Tile[_height];
            
            for (var y = 0; y < _height; y++)
            {
                var tile = new Tile
                {
                    Floor = Floor.GetByName("Grass"),
                    InTilemapPosition = new Vector3(x * tilesGap, y * tilesGap)
                };
                _tiles[x][y] = tile;
            }
        }

        for (var x = 0; x < 10; x++)
        {
            for (var y = 0; y < 10; y++)
            {
                _tiles[x + 30][y + 30].Block = Block.GetByName("WoodenPlank");
            }
        }
        
        for (var x = 0; x < 8; x++)
        {
            for (var y = 0; y < 8; y++)
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
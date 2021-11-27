using System;
using System.Drawing;
using IO;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] private float tilesGap;
    [SerializeField] private TileBehaviour tilePrefab;

    public Tile[][] _tiles;
    private int _width, _height;

    public Vector2Int Size
    {
        get => new Vector2Int(_width, _height);
        set
        {
            _width = value.x;
            _height = value.y;
        }
    }

    public float TilesGap => tilesGap;

    public void InitTilesArray()
    {
        _tiles = new Tile[_width][];

        for (var x = 0; x < _width; x++)
        {
            _tiles[x] = new Tile[_height];
        }
    }

    public void Build()
    {
        foreach (var t in _tiles)
        {
            foreach (var t1 in t)
            {
                AddTile(t1);
            }
        }
    }

    public void Dispose()
    {
        foreach (var tile in GetComponentsInChildren<TileBehaviour>())
        {
            Destroy(tile.gameObject);
        }
    }

    public Tile GetTile(int x, int y)
    {
        return _tiles[x][y];
    }

    public void SetTile(int x, int y, Tile tile)
    {
        _tiles[x][y] = tile;
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

        if (createdTile == null) return;
        
        createdTile.Tile = tile;
        createdTile.Tile.Block = tile.Block;
    }
    
    public void Write(Writes writes)
    {
        writes.Int(_width);
        writes.Int(_height);

        for (var x = 0; x < _width; x++)
        {
            for (var y = 0; y < _height; y++)
            {
                GetTile(x, y).Write(writes);
            }
        }
    }
}
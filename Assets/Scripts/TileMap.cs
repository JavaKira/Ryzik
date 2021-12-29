using System;
using System.Drawing;
using IO;
using UnityEngine;
using UnityEngine.Events;

public class TileMap : MonoBehaviour
{
    [SerializeField] private float tilesGap;
    [SerializeField] private TileBehaviour tilePrefab;

    private Tile[][] _tiles;
    private int _width, _height;

    public UnityEvent Changed { get; private set; }

    private void Awake()
    {
        Changed = new UnityEvent();
    }

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

    public bool InBounds(int x, int y)
    {
        if (x < 0 || y < 0) return false;
        return !(x > Size.x - 1) && !(y > Size.y - 1);
    }

    public Tile GetTileByWorldPosition(int worldX, int worldY)
    {
        return GetTile((int) (worldX / tilesGap), (int) (worldY / tilesGap));
    }

    private void AddTile(Tile tile)
    {
        var createdTile = Instantiate(
            tilePrefab,
            new Vector2(tile.InTilemapPosition.x * tilesGap, tile.InTilemapPosition.y * tilesGap),
            Quaternion.identity,
            transform
        );

        if (createdTile == null) return;
        
        createdTile.Tile = tile;
        createdTile.Tile.Block = tile.Block;
        tile.Changed.AddListener(Changed.Invoke);
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
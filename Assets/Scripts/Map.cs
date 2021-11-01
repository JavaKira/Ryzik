using System;
using IO;
using UnityEngine;

public class Map : MonoBehaviour
{
    private TileMap _tilemap;

    public string Name { get; set; }

    private void Awake()
    {
        _tilemap = GetComponentInChildren<TileMap>();
    }

    public void Read(Reads reads)
    {
        var width = reads.Int();
        var height = reads.Int();
        _tilemap.Size = new Vector2Int(width, height);
        _tilemap.InitTilesArray();
        var size = _tilemap.Size;
        
        for (var x = 0; x < size.x; x++)
        {
            for (var y = 0; y < size.y; y++)
            {
                var tile = new Tile();
                tile.Read(reads);
                tile.InTilemapPosition = new Vector2(x * _tilemap.TilesGap, y * _tilemap.TilesGap);
                _tilemap.SetTile(x, y, tile);
            }
        }
        _tilemap.Build();
    }

    public void Write(Writes writes)
    {
        var size = _tilemap.Size;
        var width = size.x;
        var height = size.y;
  
        writes.Int(width);
        writes.Int(height);

        for (var x = 0; x < size.x; x++)
        {
            for (var y = 0; y < size.y; y++)
            {
                _tilemap.GetTile(x, y).Write(writes);
            }
        }
    }
}
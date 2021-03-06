using System;
using Content;
using IO;
using UnityEngine;
using UnityEngine.Events;

public class Map : MonoBehaviour
{
    public static Map Instance;
    
    private TileMap _tilemap;
    private Mobs _mobs;

    public string Name { get; set; }
    public TileMap Tilemap => _tilemap;
    public Mobs Mobs => _mobs;
    public UnityEvent Loaded { get; private set; }
    public UnityEvent Changed { get; private set; }

    private void Awake()
    {
        Instance = this;
        _tilemap = GetComponentInChildren<TileMap>();
        _mobs = new Mobs();
        Loaded = new UnityEvent();
        Changed = new UnityEvent();
        
        Loaded.AddListener(Changed.Invoke);
        Mobs.Changed.AddListener(Changed.Invoke);
        Tilemap.Changed.AddListener(Changed.Invoke);
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
                tile.InTilemapPosition = new Vector2(x, y);
                _tilemap.SetTile(x, y, tile);
            }
        }
        _tilemap.Build();
        
        _mobs.Read(reads);

        if (_mobs.GetByName("Ryzik").Count == 0)
            Mob.GetByName("Ryzik").Spawn(new Vector2(0, 0));
        
        Loaded.Invoke();
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
        
        _mobs.Write(writes);
    }
}
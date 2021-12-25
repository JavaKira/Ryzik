using System;
using Content;
using IO;
using TMPro;
using UnityEngine;

public class EditorMapLoader : MonoBehaviour
{
    [SerializeField] private Vector2 defaultMapSize;
    [SerializeField] private TMP_InputField mapNameField;
    [SerializeField] private Map map;

    private void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        map.Tilemap.Size = new Vector2Int((int) defaultMapSize.x, (int) defaultMapSize.y);
        map.Tilemap.InitTilesArray();
        
        for (var x = 0; x < defaultMapSize.x; x++)
        {
            for (var y = 0; y < defaultMapSize.y; y++)
            {
                var tile = new Tile
                {
                    InTilemapPosition = new Vector2(x, y),
                    Floor = Floor.GetByName("Grass")
                };

                map.Tilemap.SetTile(x, y, tile);
            }
        }
        
        map.Tilemap.Build();
    }
    
    public void Load()
    {
        if (mapNameField.text.Length != 0)
            MapIO.Load(map, mapNameField.text);
        else
            mapNameField.Select();
    }
}
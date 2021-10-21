using System;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    private Tile _tile;

    public Tile Tile
    {
        get => _tile;
        set
        {
            _tile = value;
            Tile.Changed.AddListener(Init);
        }
    }

    private void Init()
    {
        GetComponent<SpriteRenderer>().sprite = _tile.Block.Sprite;
    }
}
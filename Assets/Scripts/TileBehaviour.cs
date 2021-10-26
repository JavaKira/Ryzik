using System;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    private Tile _tile;

    private GameObject _block;
    private GameObject _floor;

    public Tile Tile
    {
        get => _tile;
        set
        {
            _tile = value;
            Tile.Changed.AddListener(Init);
        }
    }

    private void Awake()
    {
        var child = GetComponentsInChildren<SpriteRenderer>();
        _block = child[0].gameObject;
        _floor = child[1].gameObject;
    }

    private void Init()
    {
        _block.GetComponent<SpriteRenderer>().sprite = _tile.Block.Sprite;
        _floor.GetComponent<SpriteRenderer>().sprite = _tile.Floor.Sprite;
    }
}
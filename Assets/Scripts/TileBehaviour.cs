using System;
using Content;
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
        SetBlock(_tile.Block);
        SetFloor(_tile.Floor);
    }

    private void SetFloor(Floor floor)
    {
        if (_floor != null)
            Destroy(_floor);
        
        _floor = Instantiate(floor, transform).gameObject;
    }
    
    private void SetBlock(Block block)
    {
        if (_block != null)
            Destroy(_block);

        _block = Instantiate(block, transform).gameObject;
    }
}
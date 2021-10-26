using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tile
{
    private Vector2 _inTilemapPosition;
    private Block _block;
    private Floor _floor;

    public readonly UnityEvent Changed = new UnityEvent();

    public Vector2 InTilemapPosition
    {
        get => _inTilemapPosition;
        set => _inTilemapPosition = value;
    }

    public Block Block
    {
        get => _block;
        set
        {
            _block = value;
            Changed.Invoke();
        }
    }
    
    public Floor Floor
    {
        get => _floor;
        set
        {
            _floor = value;
            Changed.Invoke();
        }
    }
}

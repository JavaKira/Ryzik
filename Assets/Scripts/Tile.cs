using System.Collections;
using System.Collections.Generic;
using IO;
using UnityEngine;
using UnityEngine.Events;

public class Tile
{
    private Vector2 _inTilemapPosition;
    private Block _block = Block.GetAir();
    private Floor _floor = Floor.GetAir();

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
    
    public void Read(Reads reads)
    {
        _block = Content.GetByID<Block>(reads.Int());
        _floor = Content.GetByID<Floor>(reads.Int());
    }

    public void Write(Writes writes)
    {
        writes.Int(_block.GetID());
        writes.Int(_floor.GetID());
    }

    public void SetIContent(IContent content)
    {
        switch (content)
        {
            case Block block:
                _block = block;
                break;
            case Floor floor:
                _floor = floor;
                break;
        }
        
        Changed.Invoke();
    }
}

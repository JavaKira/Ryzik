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
        var block = Block.GetByName(reads.String());
        if (block != null)
            _block = block;
        
        var floor = Floor.GetByName(reads.String());
        if (floor != null)
            _floor = floor;
    }

    public void Write(Writes writes)
    {
        writes.String(_block.GetName());
        writes.String(_floor.GetName());
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

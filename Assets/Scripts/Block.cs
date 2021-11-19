﻿using UnityEngine;

public class Block : MonoBehaviour, IMappableContent
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private BoxCollider2D bounds;

    public int id;
    public Sprite Sprite => sprite;
    public BoxCollider2D Bounds => bounds;

    public static Block GetAir()
    {
        return GetByName("Air");
    }
    
    public static Block GetByName(string name)
    {
        return Resources.Load<Block>("blocks/" + name);
    }

    public static Block[] GetAll()
    {
        return Resources.LoadAll<Block>("blocks/");
    }

    public int GetID()
    {
        return id;
    }
    
    public void SetID(int newId)
    {
        id = newId;
    }
}
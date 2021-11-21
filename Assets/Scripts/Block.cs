using UnityEngine;

public class Block : Item, IMappableContent
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private BoxCollider2D bounds;
    
    public Sprite Sprite => sprite;
    public BoxCollider2D Bounds => bounds;

    public static Block GetAir()
    {
        return GetByName("Air");
    }
    
    public new static Block GetByName(string name)
    {
        return Resources.Load<Block>("blocks/" + name);
    }

    public new static Block[] GetAll()
    {
        return Resources.LoadAll<Block>("blocks/");
    }
}
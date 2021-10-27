using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private BoxCollider2D bounds;

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
}
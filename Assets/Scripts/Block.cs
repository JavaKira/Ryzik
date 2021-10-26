using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Sprite sprite;

    public Sprite Sprite => sprite;
    
    public static Block GetByName(string name)
    {
        return Resources.Load<Block>("blocks/" + name);
    }
}
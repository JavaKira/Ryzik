using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    
    public Sprite Sprite => sprite;
    
    public static Floor GetByName(string name)
    {
        return Resources.Load<Floor>("floors/" + name);
    }
}
using UnityEngine;

public class Floor : MonoBehaviour, IContent
{
    [SerializeField] private Sprite sprite;
    
    public Sprite Sprite => sprite;
    
    public static Floor GetAir()
    {
        return GetByName("Air");
    }
    
    public static Floor GetByName(string name)
    {
        return Resources.Load<Floor>("floors/" + name);
    }
    
    public static Floor[] GetAll()
    {
        return Resources.LoadAll<Floor>("floors/");
    }
}
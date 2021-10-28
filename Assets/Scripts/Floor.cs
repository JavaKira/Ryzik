using UnityEngine;

public class Floor : MonoBehaviour, IContent
{
    [SerializeField] private Sprite sprite;
    
    public int id;
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

    public int GetID()
    {
        return id;
    }

    public void SetID(int newId)
    {
        id = newId;
    }
}
using UnityEngine;

public class Item : MonoBehaviour, IContent
{
    [SerializeField] private Sprite sprite;

    private int _id;
    public Sprite Sprite => sprite;

    public static Item GetByName(string name)
    {
        return Resources.Load<Item>("items/" + name);
    }
    
    public static Item[] GetAll()
    {
        return Resources.LoadAll<Item>("items/");
    }

    public int GetID()
    {
        return _id;
    }

    public void SetID(int newId)
    {
        _id = newId;
    }
}
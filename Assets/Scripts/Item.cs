using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Sprite sprite;

    public static Item GetByName(string name)
    {
        return Resources.Load<Item>("items/" + name);
    }
    
    public static Item[] GetAll()
    {
        return Resources.LoadAll<Item>("items/");
    }
}
using UnityEngine;

namespace Content
{
    public class Item : MonoBehaviour, IContent
    {
        [SerializeField] private Sprite icon;
        public Sprite Icon => icon;

        public static Item GetByName(string name)
        {
            return Resources.Load<Item>("items/" + name.Replace("item.", ""));
        }
    
        public static Item[] GetAll()
        {
            return Resources.LoadAll<Item>("items/");
        }

        public virtual string GetName()
        {
            return "item." + name;
        }
    }
}
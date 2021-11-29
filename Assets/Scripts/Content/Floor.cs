using UnityEngine;

namespace Content
{
    public class Floor : Item, IMappableContent
    {
        [SerializeField] private Sprite sprite;
        public Sprite Sprite => sprite;
    
        public override string GetName()
        {
            return "floor." + name;
        }
    
        public static Floor GetAir()
        {
            return GetByName("Air");
        }
    
        public new static Floor GetByName(string name)
        {
            return Resources.Load<Floor>("floors/" + name.Replace("floor.", ""));
        }
    
        public new static Floor[] GetAll()
        {
            return Resources.LoadAll<Floor>("floors/");
        }
    }
}
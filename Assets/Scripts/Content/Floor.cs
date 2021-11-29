using UnityEngine;

namespace Content
{
    public class Floor : MonoBehaviour, IMappableContent
    {
        [SerializeField] private Sprite sprite;
        public Sprite Sprite => sprite;
    
        public string GetName()
        {
            return "floor." + name;
        }
    
        public static Floor GetAir()
        {
            return GetByName("Air");
        }
    
        public static Floor GetByName(string name)
        {
            return Resources.Load<Floor>("floors/" + name.Replace("floor.", ""));
        }
    
        public static Floor[] GetAll()
        {
            return Resources.LoadAll<Floor>("floors/");
        }
    }
}
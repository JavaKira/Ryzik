using UnityEngine;

namespace Content
{
    public class Block : Item, IMappableContent
    {
        public override string GetContentName()
        {
            return "block." + name.Replace("(Clone)", "");
        }

        public static Block GetAir()
        {
            return GetByName("Air");
        }
    
        public new static Block GetByName(string name)
        {
            return Resources.Load<Block>("blocks/" + name.Replace("block.", ""));
        }

        public new static Block[] GetAll()
        {
            return Resources.LoadAll<Block>("blocks/");
        }
    }
}
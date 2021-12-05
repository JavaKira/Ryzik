using UnityEngine;

namespace Content
{
    public class Mob : MonoBehaviour, IContent
    {
        public string GetName()
        {
            return "mob." + name;
        }

        public Mob Spawn(Vector2 position)
        {
            var instance = Instantiate(this, Map.Instance.transform);
            instance.transform.position = new Vector3(position.x, position.y);
            Map.Instance.Mobs.Add(instance);
            return instance;
        }

        public static Mob GetByName(string name)
        {
            return Resources.Load<Mob>("mobs/" + name.Replace("mob.", ""));
        }

        public static Mob[] GetAll()
        {
            return Resources.LoadAll<Mob>("mobs/");
        }
    }
}
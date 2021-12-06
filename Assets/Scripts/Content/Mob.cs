using System;
using UnityEngine;
using UnityEngine.Events;

namespace Content
{
    public class Mob : MonoBehaviour, IContent
    {
        [SerializeField] private int maxHealth;

        public int MaxHealth => maxHealth;
        public int Health { get; private set; }

        public UnityEvent healthChanged = new UnityEvent();

        private void Start()
        {
            Heal(maxHealth);
        }

        public string GetName()
        {
            return "mob." + name.Replace("(Clone)", "");
        }

        public Mob Spawn(Vector2 position)
        {
            var instance = Instantiate(this, Map.Instance.transform);
            instance.transform.position = new Vector3(position.x, position.y);
            Map.Instance.Mobs.Add(instance);
            return instance;
        }

        public void ApplyDamage(int amount)
        {
            Health -= amount;
            healthChanged.Invoke();
        }

        public void Heal(int amount)
        {
            Health += amount;
            Health = Mathf.Min(Health, maxHealth);
            healthChanged.Invoke();
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
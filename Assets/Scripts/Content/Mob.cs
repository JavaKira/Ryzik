using System;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Content
{
    public class Mob : MonoBehaviour, IContent
    {
        public static UnityEvent<Mob> MobDead = new UnityEvent<Mob>();
        
        [SerializeField] private int maxHealth;
        [SerializeField] private int enemyCollisionDamage;
        [SerializeField] private Weapon.Weapon defaultWeapon;

        public int MaxHealth => maxHealth;
        public Weapon.Weapon Weapon { get; private set; }
        public int Health { get; private set; }

        public UnityEvent healthChanged = new UnityEvent();

        private void Start()
        {
            Heal(maxHealth);
            
            healthChanged.AddListener(() =>
            {
                if (Health < 0)
                    Dead();
            });

            Weapon = GetComponentInChildren<WeaponSlot>().Build(defaultWeapon);
            Weapon.SetOwner(this);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var mob = other.gameObject.GetComponent<Mob>();
            
            if (mob != null)
                Attack(mob);
        }

        private void Attack(Mob mob)
        {
            mob.ApplyDamage(enemyCollisionDamage);
        }

        public string GetContentName()
        {
            return "mob." + name;
        }

        public Mob Spawn(Vector2 position)
        {
            var instance = Instantiate(this, Map.Instance.transform);
            instance.name = name;
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

        private void Dead()
        {
            MobDead.Invoke(this);
            Map.Instance.Mobs.Remove(this);
            Destroy(gameObject);
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
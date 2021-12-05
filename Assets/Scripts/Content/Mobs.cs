using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace Content
{
    public class Mobs
    {
        private readonly List<Mob> _mobs = new List<Mob>();
        
        public readonly UnityEvent Changed = new UnityEvent();

        public void Add(Mob mob)
        {
            _mobs.Add(mob);
            Changed.Invoke();
        }

        public List<Mob> GetByName(string name)
        {
            return _mobs.Where(mob => mob.GetName().Equals(name)).ToList();
        }
    }
}
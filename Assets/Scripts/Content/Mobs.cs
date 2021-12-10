using System.Collections.Generic;
using System.Linq;
using IO;
using UnityEngine;
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
        
        public void Remove(Mob mob)
        {
            _mobs.Remove(mob);
            Changed.Invoke();
        }

        public void Read(Reads reads)
        {
            var size = reads.Int();

            for (var i = 0; i < size; i++)
            {
                var mob = Mob.GetByName(reads.String())
                    .Spawn(new Vector2(reads.Float(), reads.Float()));
            }
        }

        public void Write(Writes writes)
        {
            writes.Int(_mobs.Count-1);

            foreach (var mob in _mobs)
            {
                var position = mob.transform.position;
                writes.String(mob.name.Replace("(Clone)", ""));
                writes.Float(position.x);
                writes.Float(position.y);
            }
        }
        
        public List<Mob> GetByName(string name)
        {
            return _mobs.Where(mob => mob.GetName().Equals(name)).ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Content
{
    public class Mobs
    {
        private List<Mob> _mobs;

        public void Add(Mob mob)
        {
            _mobs.Add(mob);
        }

        public List<Mob> GetByName(string name)
        {
            return _mobs.Where(mob => mob.name.Equals(name)).ToList();
        }
    }
}
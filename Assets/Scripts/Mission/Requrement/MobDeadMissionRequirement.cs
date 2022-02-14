using Content;
using UnityEngine;

namespace Mission.Requrement
{
    public class MobDeadMissionRequirement : MissionRequirement
    {
        private Mob _mobType;

        public MobDeadMissionRequirement(string title, Mob mobType) : base(title)
        {
            _mobType = mobType;
            AddDoneCheck();
        }

        private void AddDoneCheck()
        {
            Mob.MobDead.AddListener(mob =>
            {
                if (Map.Instance.Mobs.GetByName(_mobType.name).Count == 1)
                    DoneEvent.Invoke();
            });
        }
    }
}
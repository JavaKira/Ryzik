using Content;
using Mission.Requrement;
using UnityEngine;

namespace Mission.RequrementBuilder
{
    public class MobDeadMissionRequirementBuilder : MissionRequirementBuilder
    {
        [SerializeField] private Mob mobType;
    
        public override MissionRequirement Build()
        {
            return new MobDeadMissionRequirement(mobType);
        }
    }
}
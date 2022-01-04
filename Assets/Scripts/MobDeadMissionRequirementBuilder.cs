using System;
using Content;
using UnityEngine;

public class MobDeadMissionRequirementBuilder : MissionRequirementBuilder
{
    [SerializeField] private Mob mobType;
    
    public override MissionRequirement Build()
    {
        return new MobDeadMissionRequirement(mobType);
    }
}
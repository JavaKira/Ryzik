using System;
using Content;
using UnityEngine;

public class MobDeadMissionRequirementBuilder : MissionRequirementBuilder
{
    [SerializeField] private Mob mobType;

    /*private void Start()
    {
        _requirements.AddListener(Mob.MobDead.AddListener((deadMob) =>
        {
            if (deadMob.name.Equals(mobType.name))
                
        }));
    }*/

    protected override bool Requirements()
    {
        return true;
    }
}
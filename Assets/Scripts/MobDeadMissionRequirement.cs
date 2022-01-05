using Content;

public class MobDeadMissionRequirement : MissionRequirement
{
    private Mob _mobType;

    public MobDeadMissionRequirement(Mob mobType)
    {
        _mobType = mobType;
        AddDoneCheck();
    }

    private void AddDoneCheck()
    {
        Mob.MobDead.AddListener(mob =>
        {
            if (Map.Instance.Mobs.GetByName(_mobType.name).Count == 0)
                DoneEvent.Invoke();
        });
    }
}
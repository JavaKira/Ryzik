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
            if (mob.name.Equals(_mobType.name))
                DoneEvent.Invoke();
        });
    }
}
using System.Collections.Generic;

public class MissionType
{
    private readonly string _mapName;
    private readonly List<MissionRequirement> _missionEndRequirements;
    private readonly List<MissionRequirement> _missionFailRequirements;

    public MissionType(string mapName, List<MissionRequirement> missionEndRequirements, List<MissionRequirement> missionFailRequirements)
    {
        _mapName = mapName;
        _missionEndRequirements = missionEndRequirements;
        _missionFailRequirements = missionFailRequirements;
    }

    public void StartMission()
    {
        Game.Open(_mapName, true, "MissionClearScene");
        Mission.PresetType = this;
    }

    public void BuildMission(Mission mission)
    {
        mission.MissionEndRequirements = new List<MissionRequirement>(_missionEndRequirements);
        mission.MissionFailRequirements = new List<MissionRequirement>(_missionFailRequirements);
    }
}
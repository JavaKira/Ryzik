using System.Collections.Generic;

public class MissionType
{
    private readonly string _mapName;
    private readonly MissionRequirement _missionEndMainRequirement;
    private readonly List<MissionRequirement> _missionEndRequirements;
    private readonly List<MissionRequirement> _missionFailRequirements;

    public Mission LastMission { get; private set; }

    public MissionType(string mapName, MissionRequirement missionEndMainRequirement, List<MissionRequirement> missionEndRequirements, List<MissionRequirement> missionFailRequirements)
    {
        _mapName = mapName;
        _missionEndMainRequirement = missionEndMainRequirement;
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
        LastMission = mission;
        mission.MissionEndMainRequirement = _missionEndMainRequirement;
        mission.MissionEndRequirements = new List<MissionRequirement>(_missionEndRequirements);
        mission.MissionFailRequirements = new List<MissionRequirement>(_missionFailRequirements);
    }
}
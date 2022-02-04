using System.Collections.Generic;
using Mission.Requrement;

namespace Mission
{
    public class MissionType
    {
        private readonly string _mapName;
        public MissionRequirement MissionEndMainRequirement { get; }
        public List<MissionRequirement> MissionEndRequirements { get; }
        public List<MissionRequirement> MissionFailRequirements { get; }

        public Mission LastMission { get; private set; }

        public MissionType(string mapName, MissionRequirement missionEndMainRequirement, List<MissionRequirement> missionEndRequirements, List<MissionRequirement> missionFailRequirements)
        {
            _mapName = mapName;
            MissionEndMainRequirement = missionEndMainRequirement;
            MissionEndRequirements = missionEndRequirements;
            MissionFailRequirements = missionFailRequirements;
        }

        public void StartMission()
        {
            Game.Open(_mapName, true, "MissionClearScene");
            Mission.PresetType = this;
        }

        public void BuildMission(Mission mission)
        {
            LastMission = mission;
            mission.MissionEndMainRequirement = MissionEndMainRequirement;
            mission.MissionEndRequirements = new List<MissionRequirement>(MissionEndRequirements);
            mission.MissionFailRequirements = new List<MissionRequirement>(MissionFailRequirements);
        }
    }
}
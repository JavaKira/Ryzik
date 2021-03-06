using System.Collections.Generic;
using Mission.RequrementBuilder;
using UnityEngine;

namespace Mission
{
    public class MissionTypeBuilder : MonoBehaviour
    {
        [SerializeField] private string mapName;
        [SerializeField] private MissionRequirementBuilder missionEndMainRequirement;
        [SerializeField] private List<MissionRequirementBuilder> missionEndRequirements;
        [SerializeField] private List<MissionRequirementBuilder> missionFailRequirements;

        public MissionType Build()
        {
            return new MissionType(
                mapName,
                missionEndMainRequirement.Build(),
                missionEndRequirements.ConvertAll(input => input.Build()),
                missionFailRequirements.ConvertAll(input => input.Build())
            );
        }
    }
}
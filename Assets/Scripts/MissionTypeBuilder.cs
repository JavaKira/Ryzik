using System.Collections.Generic;
using UI;
using UnityEngine;

public class MissionTypeBuilder : MonoBehaviour
{
    [SerializeField] private string mapName;
    [SerializeField] private List<MissionRequirementBuilder> missionEndRequirements;
    [SerializeField] private List<MissionRequirementBuilder> missionFailRequirements;

    public MissionType Build()
    {
        return new MissionType(
            mapName,
            missionEndRequirements.ConvertAll(input => input.Build()),
            missionFailRequirements.ConvertAll(input => input.Build())
        );
    }
}
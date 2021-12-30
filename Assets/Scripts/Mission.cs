using System;
using System.Collections.Generic;
using Content;
using UI;
using UnityEngine;
using UnityEngine.Events;

public class Mission : MonoBehaviour
{
    public static MissionType PresetType;

    public List<MissionRequirement> MissionEndRequirements;
    public List<MissionRequirement> MissionFailRequirements;

    public void Start()
    {
        PresetType?.BuildMission(this);

        foreach (var missionEndRequirement in MissionEndRequirements)
        {
            Map.Instance.Changed.AddListener(missionEndRequirement.Update);
            missionEndRequirement.DoneEvent.AddListener(End);
            missionEndRequirement.Update();
        }
        
        foreach (var missionFailRequirement in MissionFailRequirements)
        {
            Map.Instance.Changed.AddListener(missionFailRequirement.Update);
            missionFailRequirement.DoneEvent.AddListener(Failed);
            missionFailRequirement.Update();
        }
    }

    private void Failed()
    {
        FindObjectOfType<MissionFailedPanel>(true).gameObject.SetActive(true);
    }

    private void End()
    {
        FindObjectOfType<MissionEndPanel>(true).gameObject.SetActive(true);
    }
}
using System;
using System.Collections.Generic;
using Content;
using UI;
using UnityEngine;
using UnityEngine.Events;

public class Mission : MonoBehaviour
{
    public static MissionType PresetType;

    public MissionRequirement MissionEndMainRequirement;
    public List<MissionRequirement> MissionEndRequirements;
    public List<MissionRequirement> MissionFailRequirements;

    private int _stars;
    
    public void Start()
    {
        PresetType?.BuildMission(this);
        
        MissionEndMainRequirement.DoneEvent.AddListener(AddStar);
        MissionEndMainRequirement.DoneEvent.AddListener(End);

        foreach (var missionEndRequirement in MissionEndRequirements)
        {
            missionEndRequirement.DoneEvent.AddListener(AddStar);
        }
        
        foreach (var missionFailRequirement in MissionFailRequirements)
        {
            missionFailRequirement.DoneEvent.AddListener(Failed);
        }
    }

    private void Failed()
    {
        FindObjectOfType<MissionFailedPanel>(true).gameObject.SetActive(true);
    }

    private void End()
    {
        FindObjectOfType<MissionEndPanel>(true).gameObject.SetActive(true);
        var stars = MissionStartPanel.LastPoint.Data.Stars;
        if (_stars > stars)
            MissionStartPanel.LastPoint.Data.Stars = _stars;

        Campaign.Complete(MissionStartPanel.LastPoint);
    }

    private void AddStar()
    {
        _stars++;
    }
}
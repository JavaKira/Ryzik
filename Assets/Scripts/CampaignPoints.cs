using System;
using System.Collections.Generic;
using System.Linq;
using IO;
using UI;
using UnityEngine;

public class CampaignPoints : MonoBehaviour
{
    public static CampaignPoints Instance;
    
    private List<CampaignPoint> _points;

    private void Awake()
    {
        Instance = this;
        _points = GetComponentsInChildren<CampaignPoint>().ToList();
        CampaignIO.Load();
    }

    public CampaignPoint GetByTitle(string title)
    {
        return _points.First((point => point.Title.Equals(title)));
    }

    public List<CampaignPoint> List()
    {
        return _points;
    }
}
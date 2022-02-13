using System.Collections.Generic;
using UI;
using UnityEngine.Events;

public class CampaignData
{
    public readonly List<CampaignPoint.CampaignPointData>
        _pointData = new List<CampaignPoint.CampaignPointData>();
    private int _money;

    public int Money
    {
        get => _money;
        set
        {
            Changed.Invoke();
            _money = value;
        }
    }

    public readonly UnityEvent Changed = new UnityEvent();
    
    public CampaignPoint.CampaignPointData GetData(string title)
    {
        return _pointData.Find(data => data.CampaignPointTitle.Equals(title));
    }
}
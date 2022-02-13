using System.Collections.Generic;
using UI;

public class CampaignData
{
    public readonly List<CampaignPoint.CampaignPointData>
        PointData = new List<CampaignPoint.CampaignPointData>();
    
    public CampaignPoint.CampaignPointData GetData(string title)
    {
        return PointData.Find(data => data.CampaignPointTitle.Equals(title));
    }
}
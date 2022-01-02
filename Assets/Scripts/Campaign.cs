using System;
using System.Collections.Generic;
using System.Linq;
using IO;
using UI;
using UnityEngine.SceneManagement;

public static class Campaign
{
    public static readonly List<CampaignPoint.CampaignPointData>
        PointData = new List<CampaignPoint.CampaignPointData>();

    public static bool Loaded;

    public static void Complete(CampaignPoint campaignPoint)
    {
        if (!PointData.Contains(campaignPoint.Data))
            PointData.Add(campaignPoint.Data);
        
        campaignPoint.Data.Completed = true;
        CampaignIO.Save();
    }

    public static CampaignPoint.CampaignPointData GetData(string title)
    {
        if (Loaded) return PointData.Find(data => data.CampaignPointTitle.Equals(title));
        try
        {
            CampaignIO.Load();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return PointData.Find(data => data.CampaignPointTitle.Equals(title));
    }

    public static void OpenCampaignRoad()
    {
        SceneManager.LoadScene("CampaignRoadScene");
    }
}
using System;
using IO;
using UI;
using UnityEngine.SceneManagement;

public static class Campaign
{
    private static CampaignData _data;
    private static bool _loaded;

    public static void Complete(CampaignPoint campaignPoint)
    {
        if (!_data.PointData.Contains(campaignPoint.Data))
            _data.PointData.Add(campaignPoint.Data);
        
        campaignPoint.Data.Completed = true;
        CampaignIO.Save(_data);
    }

    public static CampaignData GetData()
    {
        if (_loaded) return _data;
        
        try
        {
            _data = CampaignIO.Load();
            _loaded = true;
        }
        catch (Exception e)
        {
            _data = new CampaignData();
            Console.WriteLine(e);
        }

        return _data;
    }

    public static void OpenCampaignRoad()
    {
        SceneManager.LoadScene("CampaignRoadScene");
    }
}
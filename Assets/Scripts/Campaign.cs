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
        if (!_data._pointData.Contains(campaignPoint.Data))
            _data._pointData.Add(campaignPoint.Data);
        
        campaignPoint.Data.Completed = true;
        CampaignIO.Save(_data);
    }

    public static CampaignData GetData()
    {
        if (_loaded) return _data;
        
        try
        {
            _data = CampaignIO.Load();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return _data;
    }

    public static void OpenCampaignRoad()
    {
        SceneManager.LoadScene("CampaignRoadScene");
    }
}
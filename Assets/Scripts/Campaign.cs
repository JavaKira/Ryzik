using System.Collections.Generic;
using IO;
using UnityEngine.SceneManagement;

public static class Campaign
{
    public static readonly List<string> CompletedPoints = new List<string>();

    public static void Complete(string name)
    {
        CompletedPoints.Add(name);
        CampaignIO.Save();
    }

    public static bool Completed(string name)
    {
        return CompletedPoints.Contains(name);
    }

    public static void OpenCampaignRoad()
    {
        SceneManager.LoadScene("CampaignRoadScene");
    }
}
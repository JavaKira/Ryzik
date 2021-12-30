using System.IO;
using UnityEngine;

namespace IO
{
    public static class CampaignIO
    {
        private const string Extension = ".rcamp";
        private const string Directory = "Campaign/";

        public static void Save()
        {
            var directory = new DirectoryInfo(Application.persistentDataPath + "/" + Directory);

            if (!directory.Exists)
                directory.Create();
            
            var name = "campaignSave";
            name += Extension;
            var fileStream = new FileStream(Application.persistentDataPath + "/" + Directory + name, FileMode.Create);
            var writer = new BinaryWriter(fileStream);
            var writes = new Writes(writer);
            
            writes.Int(CampaignPoints.Instance.List().Count);
            
            foreach (var campaignPoint in CampaignPoints.Instance.List())
            {
                writes.String(campaignPoint.Title);
                campaignPoint.Write(writes);
            }

            writes.Int(Campaign.CompletedPoints.Count);
            
            foreach (var completedPoint in Campaign.CompletedPoints)
            {
                writes.String(completedPoint);
            }
        }

        public static void Load()
        {
            var name = "campaignSave";
            name += Extension;
            var fileStream = new FileStream(Application.persistentDataPath + "/" + Directory + name, FileMode.Open);
            var reader = new BinaryReader(fileStream);
            var reads = new Reads(reader);

            var pointsCount = reads.Int();
            
            for (var i = 0; i < pointsCount; i++)
            {
                var pointTitle = reads.String();
                var point = CampaignPoints.Instance.GetByTitle(pointTitle);
                point.Read(reads);
            }

            var completedPointsCount = reads.Int();

            Campaign.CompletedPoints.Clear();
            
            for (var i = 0; i < completedPointsCount; i++)
            {
                Campaign.CompletedPoints.Add(reads.String());
            }
        }
    }
}
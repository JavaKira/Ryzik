using System.IO;
using UI;
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
      
            writes.Int(Campaign.PointData.Count);

            foreach (var data in Campaign.PointData)
            {
                writes.String(data.CampaignPointTitle);
                data.Write(writes);
            }
        }

        public static void Load()
        {
            var name = "campaignSave";
            name += Extension;
            var fileStream = new FileStream(Application.persistentDataPath + "/" + Directory + name, FileMode.Open);
            var reader = new BinaryReader(fileStream);
            var reads = new Reads(reader);

            var completedPointsCount = reads.Int();

            Campaign.PointData.Clear();
            
            for (var i = 0; i < completedPointsCount; i++)
            {
                var data = new CampaignPoint.CampaignPointData(reads.String());
                data.Read(reads);
                Campaign.PointData.Add(data);
            }

            Campaign.Loaded = true;
        }
    }
}
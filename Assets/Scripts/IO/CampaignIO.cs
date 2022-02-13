using System.IO;
using UI;
using UnityEngine;

namespace IO
{
    public static class CampaignIO
    {
        private const string Extension = ".rcamp";
        private const string Directory = "Campaign/";

        public static void Save(CampaignData data)
        {
            var directory = new DirectoryInfo(Application.persistentDataPath + "/" + Directory);

            if (!directory.Exists)
                directory.Create();
            
            var name = "campaignSave";
            name += Extension;
            var fileStream = new FileStream(Application.persistentDataPath + "/" + Directory + name, FileMode.Create);
            var writer = new BinaryWriter(fileStream);
            var writes = new Writes(writer);
      
            writes.Int(data.PointData.Count);
            writes.Int(data.Money);

            foreach (var pointData in data.PointData)
            {
                writes.String(pointData.CampaignPointTitle);
                pointData.Write(writes);
            }
        }

        public static CampaignData Load()
        {
            var name = "campaignSave";
            name += Extension;
            var fileStream = new FileStream(Application.persistentDataPath + "/" + Directory + name, FileMode.Open);
            var reader = new BinaryReader(fileStream);
            var reads = new Reads(reader);
            var data = new CampaignData();

            var completedPointsCount = reads.Int();
            data.Money = reads.Int();

            for (var i = 0; i < completedPointsCount; i++)
            {
                var pointData = new CampaignPoint.CampaignPointData(reads.String());
                pointData.Read(reads);
                data.PointData.Add(pointData);
            }
            
            return data;
        }
    }
}
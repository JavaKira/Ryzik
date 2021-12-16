using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;

namespace IO
{
    public static class PreservationsIO
    {
        private const string PreservationsExtension = ".rusav";
        private const string PreservationsDirectory = "Preservations/";

        public static void Save(Map map)
        {
            MapIO.Save(map, PreservationsDirectory + DateTime.Now.ToString(CultureInfo.InvariantCulture)
                                .Replace("/", "-").Replace(":", "-"));
        }

        public static void Load(Map map, string name)
        {
            MapIO.Load(map,PreservationsDirectory + name);
        }
        
        public static List<string> GetPreservationsList()
        {
            var dir = new DirectoryInfo(Application.persistentDataPath);
            var fileInfos = dir.GetFiles(PreservationsDirectory + "*" + PreservationsExtension);

            return fileInfos.Select(t => t.Name.Replace(t.Extension, "")).ToList();
        }
    }
}
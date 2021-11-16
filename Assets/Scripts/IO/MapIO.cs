using System.IO;
using UnityEngine;

namespace IO
{
    public static class MapIO
    {
        private const string MapSaveExtension = ".rusav";

        public static void Save(TileMap tileMap, string name)
        {
            name += MapSaveExtension;
            var fileStream = new FileStream(name, FileMode.Create);
            var writer = new BinaryWriter(fileStream);
            var writes = new Writes(writer);
            
            tileMap.Write(writes);
            
            fileStream.Close();
            writer.Close();
        }
    
        public static Map Load(Map map, string fileName)
        {
            fileName += MapSaveExtension;
            var fileStream = new FileStream(fileName, FileMode.Open);
            var reader = new BinaryReader(fileStream);
            var reads = new Reads(reader);
            map.Tilemap.Dispose();
            
            map.Read(reads);
            
            fileStream.Close();
            reader.Close();
            return map;
        }

        public static FileInfo[] GetMapsList()
        {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            return dir.GetFiles("*" + MapSaveExtension);
        }
    }
}
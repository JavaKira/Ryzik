using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

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
        
        public static Map LoadFromResources(Map map, string fileName)
        {
            var text = Resources.Load<TextAsset>("Maps/" + fileName);
            var stream = new MemoryStream(text.bytes);
            var reader = new BinaryReader(stream);
            var reads = new Reads(reader);
            map.Tilemap.Dispose();
            map.Read(reads);
            reader.Close();
            return map;
        }
        
        public static Stream GetStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static FileInfo[] GetMapsList()
        {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            return dir.GetFiles("*" + MapSaveExtension);
        }
    }
}
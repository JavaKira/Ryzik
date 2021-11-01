﻿using System.IO;

namespace IO
{
    public static class MapIO
    {
        public static void Save(TileMap tileMap, string name)
        {
            var fileStream = new FileStream(name, FileMode.Create);
            var writer = new BinaryWriter(fileStream);
            var writes = new Writes(writer);
            
            tileMap.Write(writes);
            
            fileStream.Close();
            writer.Close();
        }
    
        public static Map Load(Map map, string fileName)
        {
            var fileStream = new FileStream(fileName, FileMode.Open);
            var reader = new BinaryReader(fileStream);
            var reads = new Reads(reader);
            
            map.Read(reads);
            
            fileStream.Close();
            reader.Close();
            return map;
        }
    }
}
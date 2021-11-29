using IO;
using UnityEngine;

namespace Debug
{
    public class DebugWorldSaver : MonoBehaviour
    {
        [SerializeField] private string mapName;
        [SerializeField] private TileMap tileMap;

        public void Save()
        {
            MapIO.Save(tileMap, mapName);
        }
    }
}
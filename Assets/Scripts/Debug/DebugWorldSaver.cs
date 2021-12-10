using IO;
using UnityEngine;

namespace Debug
{
    public class DebugWorldSaver : MonoBehaviour
    {
        [SerializeField] private string mapName;
        [SerializeField] private Map map;

        public void Save()
        {
            MapIO.Save(map, mapName);
        }
    }
}
using IO;
using UnityEngine;

namespace Debug
{
    public class DebugWorldLoader : MonoBehaviour
    {
        [SerializeField] private string mapName;
        [SerializeField] private TileMap tileMap;
        [SerializeField] private bool fromResourcesFolder;

        private void Start()
        {
            if (fromResourcesFolder)
                MapIO.LoadFromResources(FindObjectOfType<Map>(), mapName);
            else
                MapIO.Load(FindObjectOfType<Map>(), mapName);
        }
    }
}
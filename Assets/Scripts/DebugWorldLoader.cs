using IO;
using UnityEngine;

public class DebugWorldLoader : MonoBehaviour
{
    [SerializeField] private string mapName;
    [SerializeField] private TileMap tileMap;

    private void Start()
    {
        MapIO.Load(FindObjectOfType<Map>(), mapName);
    }
}
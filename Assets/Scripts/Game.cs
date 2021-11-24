using System;
using IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private static string _lastMapName;
    private static bool _lastMapFromResources;

    private void Awake()
    {
        Content.Init();
        
        if (_lastMapName != null)
        {
            if (_lastMapFromResources)
                MapIO.LoadFromResources(FindObjectOfType<Map>(), _lastMapName);
            else
            {
                MapIO.Load(FindObjectOfType<Map>(), _lastMapName);
            }
        }
        
        _lastMapName = string.Empty;
    }
    
    public static void Open(string name, bool mapFromResources)
    {
        _lastMapName = name;
        SceneManager.LoadScene("SampleScene");
    }
}
using System;
using IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance;
    
    private static string _lastMapName;
    private static bool _lastMapFromResources;
    private bool _pause;

    private void Awake()
    {
        Instance = this;
        Content.Content.Init();
        
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
    
    public static void Open(string name, bool mapFromResources, string sceneName = "SampleScene")
    {
        _lastMapName = name;
        _lastMapFromResources = mapFromResources;
        SceneManager.LoadScene(sceneName);
    }

    public void Pause()
    {
        _pause = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        _pause = false;
        Time.timeScale = 1;
    }

    public bool IsPause()
    {
        return _pause;
    }
}
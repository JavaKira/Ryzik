using System;
using IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance;
    
    private static string _lastMapName;
    private static bool _lastMapFromResources;
    private static string _preservationFileName;
    private bool _pause;

    private void Start()
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
        
        if (_preservationFileName != null)
            Load();
    }

    private static void Load()
    {
        PreservationsIO.Load(Map.Instance, _preservationFileName);
        _preservationFileName = string.Empty;
    }

    public static void Load(string fileName)
    {
        _preservationFileName = fileName;
        _lastMapName = null;
        SceneManager.LoadScene("SampleScene");
    }

    public void Save()
    {
        PreservationsIO.Save(Map.Instance);
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
using System;
using IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private static string _lastMapName;

    private void Awake()
    {
        Content.Init();
        
        if (_lastMapName != null)
        {
            MapIO.Load(FindObjectOfType<Map>(), _lastMapName);
        }
        
        _lastMapName = string.Empty;
    }
    
    public static void Open(string name)
    {
        _lastMapName = name;
        SceneManager.LoadScene("SampleScene");
    }
}
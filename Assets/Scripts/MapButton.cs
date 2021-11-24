using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    private string _mapName;
    private bool _loadFromResources;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenMap);
    }

    private void OpenMap()
    {
        if (_mapName != null)
            Game.Open(_mapName, _loadFromResources);
    }
    
    public void Build(string mapName)
    {
        _mapName = mapName;
        GetComponentInChildren<TMP_Text>().text = mapName;
    }

    public void LoadFromResources()
    {
        _loadFromResources = true;
    }
}
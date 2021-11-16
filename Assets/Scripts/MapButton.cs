using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    private string _mapName;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenMap);
    }

    private void OpenMap()
    {
        if (_mapName != null)
            Game.Open(_mapName);
    }
    
    public void Build(string mapName)
    {
        _mapName = mapName;
        GetComponentInChildren<TMP_Text>().text = mapName;
    }
}
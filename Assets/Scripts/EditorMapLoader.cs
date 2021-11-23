using System;
using IO;
using TMPro;
using UnityEngine;

public class EditorMapLoader : MonoBehaviour
{
    private const string DefaultMapName = "DefaultEditorMap";
    
    [SerializeField] private TMP_InputField mapNameField;
    [SerializeField] private Map map;

    private void Start()
    {
        LoadDefault();
    }

    private void LoadDefault()
    {
        MapIO.LoadFromResources(map, DefaultMapName);
    }
    
    public void Load()
    {
        if (mapNameField.text.Length != 0)
            MapIO.Load(map, mapNameField.text);
        else
            mapNameField.Select();
    }
}
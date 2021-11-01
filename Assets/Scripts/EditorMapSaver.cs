using IO;
using TMPro;
using UnityEngine;

public class EditorMapSaver : MonoBehaviour
{
    [SerializeField] private TMP_InputField mapNameField;
    [SerializeField] private Map map;

    public void Save()
    {
        if (mapNameField.text.Length != 0)
            MapIO.Save(map.Tilemap, mapNameField.text);
        else
            mapNameField.Select();
    }
}
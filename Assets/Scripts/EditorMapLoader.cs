using IO;
using TMPro;
using UnityEngine;

public class EditorMapLoader : MonoBehaviour
{
    [SerializeField] private TMP_InputField mapNameField;
    [SerializeField] private Map map;

    public void Load()
    {
        if (mapNameField.text.Length != 0)
            MapIO.Load(map, mapNameField.text);
        else
            mapNameField.Select();
    }
}
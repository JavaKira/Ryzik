using IO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EditorMapSaver : MonoBehaviour
{
    [SerializeField] private TMP_InputField mapNameField;
    [SerializeField] private Map map;

    public UnityEvent onSaveSuccessfully;
    
    public void Save()
    {
        if (mapNameField.text.Length != 0)
        {
            onSaveSuccessfully.Invoke();
            MapIO.Save(map, mapNameField.text);
        }
        else
            mapNameField.Select();
    }
}
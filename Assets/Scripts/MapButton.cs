using TMPro;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    public void Build(string mapName)
    {
        GetComponentInChildren<TMP_Text>().text = mapName;
    }
}
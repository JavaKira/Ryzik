using System;
using UnityEngine;

public class MapSelectBuilder : MonoBehaviour
{
    [SerializeField] private string[] maps;
    [SerializeField] private float gap;
    [SerializeField] private MapButton mapButtonPrefab;

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        for (var i = 0; i < maps.Length; i++)
        {
            var mapButton = Instantiate(
                mapButtonPrefab,
                transform
            );

            var transform1 = mapButton.transform;
            var mapButtonRectangleTransform = (RectTransform) transform1;
            
            transform1.localPosition += new Vector3(
                0,
                i * mapButtonRectangleTransform.sizeDelta.y + gap * i,
                0
            );
            
            mapButton.Build(maps[i]);
        }
    }
}
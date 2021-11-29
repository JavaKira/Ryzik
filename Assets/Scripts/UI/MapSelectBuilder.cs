using System.Collections.Generic;
using IO;
using UnityEngine;

namespace UI
{
    public class MapSelectBuilder : MonoBehaviour
    {
        [SerializeField] private float gap;
        [SerializeField] private MapButton mapButtonPrefab;

        private void Start()
        {
            Build();
        }

        private void Build()
        {
            var maps = new List<string>(MapIO.GetMapsList());

            maps.Add("EmptyMap");

            for (var i = 0; i < maps.Count; i++)
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

                if (maps[i].Equals("EmptyMap"))
                    mapButton.LoadFromResources();
            }

            ((RectTransform) transform).sizeDelta = new Vector2(
                ((RectTransform) transform).sizeDelta.x,
                (((RectTransform) mapButtonPrefab.transform).sizeDelta.y + gap) * maps.Count
            );
        }
    }
}
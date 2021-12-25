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

            var resourcesMaps = new List<string>(new []{"EmptyMap", "Surrounded"});

            for (var i = 0; i < maps.Count; i++)
            {
                BuildItem(maps[i], false, i);
            }

            for (var i = 0; i < resourcesMaps.Count; i++)
            {
                BuildItem(resourcesMaps[i], true, maps.Count + i);
            }

            ((RectTransform) transform).sizeDelta = new Vector2(
                ((RectTransform) transform).sizeDelta.x,
                (((RectTransform) mapButtonPrefab.transform).sizeDelta.y + gap) * maps.Count
            );
        }

        private void BuildItem(string mapName, bool loadFromResources, int number)
        {
            var mapButton = Instantiate(
                mapButtonPrefab,
                transform
            );

            var transform1 = mapButton.transform;
            var mapButtonRectangleTransform = (RectTransform) transform1;

            transform1.localPosition += new Vector3(
                0,
                number * mapButtonRectangleTransform.sizeDelta.y + gap * number,
                0
            );

            mapButton.Build(mapName);

            if (loadFromResources)
                mapButton.LoadFromResources();
        }
    }
}
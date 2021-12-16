using System.Collections.Generic;
using Content;
using IO;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class PreservationListBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject preservationPrefab;
        [SerializeField] private float gap;

        private void Start()
        {
            Build();
        }

        private void Build()
        {
            var items = new List<string>();
            items.AddRange(PreservationsIO.GetPreservationsList());

            for (var i = 0; i < items.Count; i++)
            {
                var item = Instantiate(preservationPrefab, transform);
                var itemRectTransform = (RectTransform) item.transform;
                itemRectTransform.localPosition += new Vector3(
                    0,
                    i * itemRectTransform.sizeDelta.y + gap * i,
                    0
                );
                item.GetComponent<PreservationItem>().Build(items[i]);
            }

            ((RectTransform) transform).sizeDelta = new Vector2(
                ((RectTransform) transform).sizeDelta.x,
                (((RectTransform) preservationPrefab.transform).sizeDelta.y + gap) * items.Count
            );
        }
    }
}
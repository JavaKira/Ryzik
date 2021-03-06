using System.Collections.Generic;
using Content;
using UnityEngine;

namespace UI
{
    public class ContentSelectBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject contentSelectItemPrefab;
        [SerializeField] private float gap;

        private void Start()
        {
            Build();
        }

        private void Build()
        {
            var items = new List<IContent>();
            items.AddRange(Block.GetAll());
            items.AddRange(Floor.GetAll());
            items.AddRange(Mob.GetAll());

            for (var i = 0; i < items.Count; i++)
            {
                var item = Instantiate(contentSelectItemPrefab, transform);
                var itemRectTransform = (RectTransform) item.transform;
                itemRectTransform.localPosition += new Vector3(
                    0,
                    i * itemRectTransform.sizeDelta.y + gap * i,
                    0
                );
                item.GetComponent<ContentSelectItemBehaviour>().Content =
                    ((MonoBehaviour) items[i]).GetComponent<IContent>();
            }

            ((RectTransform) transform).sizeDelta = new Vector2(
                ((RectTransform) transform).sizeDelta.x,
                (((RectTransform) contentSelectItemPrefab.transform).sizeDelta.y + gap) * items.Count
            );
        }
    }
}
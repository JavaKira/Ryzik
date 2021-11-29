using Content;
using UnityEngine;

namespace UI
{
    public class SandboxInventoryBuilder : MonoBehaviour
    {
        [SerializeField] private ItemSlot slotPrefab;
        [SerializeField] private int slotsPerLine;
        [SerializeField] private int gap;

        private void Start()
        {
            Build();
        }

        private void Build()
        {
            var content = Content.Content.GetByType<Item>();
            var line = default(int);
            var column = default(int);

            foreach (var item in content)
            {
                if (item.name == "Air") continue;

                var slot = Instantiate(slotPrefab, transform);
                slot.SetItem(item);

                var slotTransform = (RectTransform) slot.transform;
                var sizeDelta = slotTransform.sizeDelta;

                slotTransform.localPosition += new Vector3(
                    column * sizeDelta.x + gap * column,
                    -line * sizeDelta.y - gap * line
                );

                column++;
                if (column < slotsPerLine) continue;
                line++;
                column = 0;
            }
        }
    }
}
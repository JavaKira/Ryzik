using UnityEngine.EventSystems;

public class SandboxItemSlot : ItemSlot
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        var cursor = Cursor.Instance;
        if (cursor == null) return;

        cursor.SetItem(cursor.Empty() ? Item : null);
    }        
}
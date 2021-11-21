using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private TileMap tileMap;
    [SerializeField] private Hotbar hotbar;

    private void FixedUpdate()
    {
        if (EditorInput.IsMouseOverUI() && hotbar.SelectedSlot == null) return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(1))
        {
            tileMap.GetTileByWorldPosition((int) mousePosition.x, (int) mousePosition.y)
                    .SetIContent(hotbar.SelectedSlot.Item);
        }

        if (Input.GetMouseButtonDown(0))
        {
            tileMap.GetTileByWorldPosition((int) mousePosition.x, (int) mousePosition.y)
                    .Block = Block.GetAir();
        }
    }

    public void Move(Vector2 direction)
    {
        var moveDirectionForce = new Vector3(direction.x, direction.y , 0.0f);
        moveDirectionForce *= speed;

        transform.Translate(moveDirectionForce * Time.fixedDeltaTime);
    }
}

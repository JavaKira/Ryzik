using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private TileMap tileMap;
    [SerializeField] private Hotbar hotbar;

    private float _mouseDragTime;

    private void Update()
    {
        if (Game.Instance.IsPause() || Input.touchCount == 0) return;
        
        var touch = Input.GetTouch(Input.touchCount - 1);
        if (EditorInput.IsMouseOverUI(touch.fingerId)) return;
        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(touch.position);

        if (touch.phase == TouchPhase.Stationary)
            _mouseDragTime += Time.deltaTime;
        else
            _mouseDragTime = 0;
        
        if (_mouseDragTime > 0.5f)
        {
            tileMap.GetTile(
                (int) ((mousePosition.x + 4) / 8), 
                (int) ((mousePosition.y + 4) / 8)
            ).Block = Block.GetAir();
            
            return;
        }
        
        if (touch.phase == TouchPhase.Began && hotbar.SelectedSlot != null)
        {
            tileMap.GetTile(
                    (int) ((mousePosition.x + 4) / 8), 
                    (int) ((mousePosition.y + 4) / 8)
            ).SetIContent(hotbar.SelectedSlot.Item);
        }
    }
    public void Move(Vector2 direction)
    {
        var moveDirectionForce = new Vector3(direction.x, direction.y , 0.0f);
        moveDirectionForce *= speed;

        transform.Translate(moveDirectionForce * Time.fixedDeltaTime);
    }
}

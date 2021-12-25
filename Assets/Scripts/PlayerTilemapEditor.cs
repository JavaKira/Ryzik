using System;
using Content;
using UI;
using UnityEngine;

public class PlayerTilemapEditor : MonoBehaviour
{
    [SerializeField] private TileMap tileMap;
    [SerializeField] private Hotbar hotbar;

    private float _mouseDragTime;

    private void Start()
    {
        if (tileMap == null)
            tileMap = FindObjectOfType<TileMap>();
        
        if (hotbar == null)
            hotbar = FindObjectOfType<Hotbar>();
    }

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
            var tile = tileMap.GetTile(
                (int) ((mousePosition.x + 4) / 8),
                (int) ((mousePosition.y + 4) / 8)
            );

            if (tile.Block.name != "Air")
            {
                tile.Block = Block.GetAir();
                _mouseDragTime = 0;
                return;
            }
            
            if (tile.Floor.name != "Air")
                tile.Floor = Floor.GetAir();
            
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
}
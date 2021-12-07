using System;
using Content;
using UnityEngine;
using UnityEngine.EventSystems;

public class EditorInput : MonoBehaviour
{
    public static EditorInput Main;

    [SerializeField] private TileMap tileMap;
    [SerializeField] private GameObject cameraPoint;
    [SerializeField] private float moveSpeed;

    public IContent SelectedContent { get; set; }

    private void Start()
    {
        Main = this;
    }

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Game.Instance.IsPause() || Input.touchCount == 0) return;
        
        var touch = Input.GetTouch(Input.touchCount - 1);
        if (IsMouseOverUI(touch.fingerId)) return;
        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (touch.phase == TouchPhase.Began)
        {
            if (SelectedContent is Mob mob)
                mob.Spawn(mousePosition);
            else
                tileMap.GetTile(
                    (int) ((mousePosition.x + 4) / 8),
                    (int) ((mousePosition.y + 4) / 8)
                ).SetIContent(SelectedContent);
        }
    }

    public static bool IsMouseOverUI(int touchID)
    {
        return EventSystem.current.IsPointerOverGameObject(touchID);
    }

    private void Move(Vector3 direction)
    {
        cameraPoint.transform.position += direction * (moveSpeed * Time.deltaTime);
    }
}
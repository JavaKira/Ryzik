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
    
    private float _mouseDragTime;

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
        
        if (touch.phase == TouchPhase.Stationary)
            _mouseDragTime += Time.deltaTime;
        else
            _mouseDragTime = 0;
        
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (_mouseDragTime > 0.5f)
        {
            var mobAtMouse = GetMobAtPoint(mousePosition);
            if (mobAtMouse != null)                       
            {                                             
                Map.Instance.Mobs.Remove(mobAtMouse);     
                Destroy(mobAtMouse.gameObject);           
            }  
            
            return;
        }
        
        if (touch.phase == TouchPhase.Began)
        {
            if (SelectedContent is Mob mob && GetMobAtPoint(mousePosition) == null)
                mob.Spawn(mousePosition);
            else
                tileMap.GetTile(
                    (int) ((mousePosition.x + 4) / 8),
                    (int) ((mousePosition.y + 4) / 8)
                ).SetIContent(SelectedContent);
        }
    }

    private static Mob GetMobAtPoint(Vector2 point)
    {
        var hit = Physics2D.Raycast(new Vector2(point.x, point.y), Vector2.zero);
        return hit.collider != null ? hit.collider?.gameObject.GetComponent<Mob>() : null;
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